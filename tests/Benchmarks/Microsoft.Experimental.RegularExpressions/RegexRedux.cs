// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Microsoft.Collections.Extensions.Benchmarks;
using BenchmarkDotNet.Attributes;

using Original = System.Text.RegularExpressions;
using PCRE = Microsoft.Experimental.RegularExpressions;

namespace Microsoft.Experimental.RegularExpressions.Benchmarks
{
    [WarmupCount(0)]
    [IterationCount(1)]
    [GcConcurrent(true)]
    [GcServer(true)]
    public class RegexRedux
    {
        [Params(250_000)] // , 2_500_000, 25_000_000)] // uncomment for slower benchmarks
        public int Size { get; set; }

        public string Filename => Path.Combine(Path.GetTempPath(),
            "corefxlab_dictionaryslim_input" + Size + ".txt");

        [GlobalSetup]
        public void CreateValuesList()
        {
            if (!File.Exists(Filename))
            {
                using (var fs = File.Create(Filename))
                {
                    DictionarySlimFasta.Create(Size, fs);
                }
            }
        }

        string[] _results;

        [GlobalCleanup]
        public void CheckResults()
        {
            var result = string.Join(" // ", _results.Select(i => i.Replace('\n', 'n').Replace("\r", "")));
            var expected = Size == 250_000 ? "agggtaaa|tttaccct 18 // [cgt]gggtaaa|tttaccc[acg] 63 // a[act]ggtaaa|tttacc[agt]t 211 // ag[act]gtaaa|tttac[agt]ct 145 // agg[act]taaa|ttta[agt]cct 273 // aggg[acg]aaa|ttt[cgt]ccct 77 // agggt[cgt]aa|tt[acg]accct 72 // agggta[cgt]a|t[acg]taccct 79 // agggtaa[cgt]|[acg]ttaccct 110 // n2541745n2500000 // 1369394"
                         : Size == 2_500_000 ? "A 30.297nT 30.151nC 19.798nG 19.755njAA 9.177nTA 9.133nAT 9.131nTT 9.091nCA 6.002nAC 6.001nAG 5.987nGA 5.984nCT 5.971nTC 5.971nGT 5.957nTG 5.956nCC 3.917nGC 3.910nCG 3.909nGG 3.903nj147166	GGTj44658	GGTAj4736	GGTATTj89	GGTATTTTAATTj89	GGTATTTTAATTTATAGT"
                         : Size == 25_000_000 ? "A 30.295nT 30.151nC 19.800nG 19.754njAA 9.177nTA 9.132nAT 9.131nTT 9.091nCA 6.002nAC 6.001nAG 5.987nGA 5.984nCT 5.971nTC 5.971nGT 5.957nTG 5.956nCC 3.917nGC 3.911nCG 3.909nGG 3.902nj1471758	GGTj446535	GGTAj47336	GGTATTj893	GGTATTTTAATTj893	GGTATTTTAATTTATAGT"
                         : "?";
            if (result != expected) throw new Exception("Incorrect result: " + result);
        }

        [Benchmark(Baseline = true)]
        public void RegexRedux_Original() => _results = new RegexRedux_Original().Main(Size, Filename);
        [Benchmark]
        public void RegexRedux_PCRE() => _results = new RegexRedux_PCRE().Main(Size, Filename);
    }

    public class RegexRedux_PCRE
    {
        static PCRE.Regex regex(string re)
        {
            return new PCRE.Regex(re, RegexOptions.Compiled);
        }

        static string regexCount(string s, string r)
        {
            int c = Regex.MatchCount(s, r, RegexOptions.Compiled);
            return r + " " + c;
        }

        public string[] Main(int size, string filename)
        {
            var sequences = File.ReadAllText(filename);
            var initialLength = sequences.Length;
            sequences = PCRE.Regex.Replace(sequences, ">.*\n|\n", "");

            var magicTask = Task.Run(() =>
            {
                var newseq = regex("tHa[Nt]").Replace(sequences, "<4>");
                newseq = regex("aND|caN|Ha[DS]|WaS").Replace(newseq, "<3>");
                newseq = regex("a[NSt]|BY").Replace(newseq, "<2>");
                newseq = regex("<[^>]*>").Replace(newseq, "|");
                newseq = regex("\\|[^|][^|]*\\|").Replace(newseq, "-");
                return newseq.Length;
            });

            var variant2 = Task.Run(() => regexCount(sequences, "[cgt]gggtaaa|tttaccc[acg]"));
            var variant3 = Task.Run(() => regexCount(sequences, "a[act]ggtaaa|tttacc[agt]t"));
            var variant7 = Task.Run(() => regexCount(sequences, "agggt[cgt]aa|tt[acg]accct"));
            var variant6 = Task.Run(() => regexCount(sequences, "aggg[acg]aaa|ttt[cgt]ccct"));
            var variant4 = Task.Run(() => regexCount(sequences, "ag[act]gtaaa|tttac[agt]ct"));
            var variant5 = Task.Run(() => regexCount(sequences, "agg[act]taaa|ttta[agt]cct"));
            var variant1 = Task.Run(() => regexCount(sequences, "agggtaaa|tttaccct"));
            var variant9 = Task.Run(() => regexCount(sequences, "agggtaa[cgt]|[acg]ttaccct"));
            var variant8 = Task.Run(() => regexCount(sequences, "agggta[cgt]a|t[acg]taccct"));

            return new[] {
                variant1.Result,
                variant2.Result,
                variant3.Result,
                variant4.Result,
                variant5.Result,
                variant6.Result,
                variant7.Result,
                variant8.Result,
                variant9.Result,
                "\n"+initialLength+"\n"+sequences.Length,
                magicTask.Result.ToString()
            };
        }
    }

    public class RegexRedux_Original
    {
        static Original.Regex regex(string re)
        {
            return new Original.Regex(re, Original.RegexOptions.Compiled);
        }

        static string regexCount(string s, string r)
        {
            int c = 0;
            var m = regex(r).Match(s);
            while(m.Success) { c++; m = m.NextMatch(); }
            return r + " " + c;
        }

        public string[] Main(int size, string filename)
        {
            var sequences = File.ReadAllText(filename);
            var initialLength = sequences.Length;
            sequences = Original.Regex.Replace(sequences, ">.*\n|\n", "");

            var magicTask = Task.Run(() =>
            {
                var newseq = regex("tHa[Nt]").Replace(sequences, "<4>");
                newseq = regex("aND|caN|Ha[DS]|WaS").Replace(newseq, "<3>");
                newseq = regex("a[NSt]|BY").Replace(newseq, "<2>");
                newseq = regex("<[^>]*>").Replace(newseq, "|");
                newseq = regex("\\|[^|][^|]*\\|").Replace(newseq, "-");
                return newseq.Length;
            });

            var variant2 = Task.Run(() => regexCount(sequences, "[cgt]gggtaaa|tttaccc[acg]"));
            var variant3 = Task.Run(() => regexCount(sequences, "a[act]ggtaaa|tttacc[agt]t"));
            var variant7 = Task.Run(() => regexCount(sequences, "agggt[cgt]aa|tt[acg]accct"));
            var variant6 = Task.Run(() => regexCount(sequences, "aggg[acg]aaa|ttt[cgt]ccct"));
            var variant4 = Task.Run(() => regexCount(sequences, "ag[act]gtaaa|tttac[agt]ct"));
            var variant5 = Task.Run(() => regexCount(sequences, "agg[act]taaa|ttta[agt]cct"));
            var variant1 = Task.Run(() => regexCount(sequences, "agggtaaa|tttaccct"));
            var variant9 = Task.Run(() => regexCount(sequences, "agggtaa[cgt]|[acg]ttaccct"));
            var variant8 = Task.Run(() => regexCount(sequences, "agggta[cgt]a|t[acg]taccct"));

            return new[] {
                variant1.Result,
                variant2.Result,
                variant3.Result,
                variant4.Result,
                variant5.Result,
                variant6.Result,
                variant7.Result,
                variant8.Result,
                variant9.Result,
                "\n"+initialLength+"\n"+sequences.Length,
                magicTask.Result.ToString()
            };
        }
    }
}
