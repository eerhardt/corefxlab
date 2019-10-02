using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.Experimental.RegularExpressions
{
    // FUTURE: Rather than mimicking the .NET API,
    // trim down to something smaller that also allocates less (Span, structs, simpler API..)
    // and omits non-PCRE features (timeout, invariant, Capture, RTL, ..)
    // Possibly support non-.NET features (partial match, ..)
    public unsafe class Regex
    {
        // This (pcre2_code_16) is thread safe, so the compiled result here could be cached.
        // match_data is not thread safe, but is reusable, so it could be cached on the thread.
        // TODO: free with pcre2_code_free on Dispose(), and pcre2_match_data_free if we cached that
        private IntPtr _code;
        private RegexOptions _options;

        public Regex(string pattern)
            : this(pattern, RegexOptions.None)
        {
        }

        public Regex(string pattern, RegexOptions options)
            : this(pattern, options, TimeSpan.MaxValue)
        {
        }

        public Regex(string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            if (pattern == null)
                throw new ArgumentNullException("pattern");

            int errorcode = 0;
            int erroroffset = 0;
            uint opt = Interop.PCRE2_UTF; // causes correct Unicode casing

            _options = options;
            if ((options & RegexOptions.IgnorePatternWhitespace) != 0)
                opt |= Interop.PCRE2_EXTENDED; // But not also PCRE2_EXTENDED_MORE
            if ((options & RegexOptions.Multiline) != 0)
                opt |= Interop.PCRE2_MULTILINE;
            if ((options & RegexOptions.Singleline) != 0)
                opt |= Interop.PCRE2_DOTALL;
            if ((options & RegexOptions.IgnoreCase) != 0)
                opt |= Interop.PCRE2_CASELESS;
            if ((options & RegexOptions.ExplicitCapture) != 0)
                opt |= Interop.PCRE2_NO_AUTO_CAPTURE;
            if ((options & RegexOptions.RightToLeft) != 0)
                throw new ArgumentException("PCRE does not support RTL");
            if ((options & RegexOptions.ECMAScript) != 0)
                throw new ArgumentException("PCRE does not support ECMAScript option");
            if ((options & RegexOptions.CultureInvariant) != 0)
                throw new ArgumentException("PCRE does not support invariant culture");

            // TODO: passing no "context" here - do we need one?
            // default newline behavior was set in build by NEWLINE_DEFAULT, we want to retain the default PCRE2_NEWLINE_LF because .NET only recognises \n
            _code = Interop.pcre2_compile(pattern, new IntPtr(pattern.Length), opt, &errorcode, new IntPtr(&erroroffset), ccontext:IntPtr.Zero);

            if (_code == IntPtr.Zero)
            {
                throw new ArgumentException($"ERR{errorcode} Invalid pattern. {Interop.GetMessage(errorcode)} at offset {erroroffset}", "pattern");
            }

            if ((options & RegexOptions.Compiled) != 0)
            {
                errorcode = Interop.pcre2_jit_compile(_code, options: Interop.PCRE2_JIT_COMPLETE);
                if (errorcode == Interop.PCRE2_ERROR_JIT_BADOPTION)
                    throw new ArgumentException("Recompile PCRE with JIT support");
                if (errorcode < 0) // ignore result? PCRE will fall back to interpreted...
                    throw new ArgumentException($"ERR{errorcode} Compilation failed. {Interop.GetMessage(errorcode)}");
            }
        }

        public static int CacheSize
        {
            get => throw null;
            set
            {
            }
        }

        public TimeSpan MatchTimeout => throw null;

        public RegexOptions Options => _options;

        public bool RightToLeft => false; // PCRE does not support

        public static string Escape(string str)
        {
            throw null;
        }

        public string[] GetGroupNames()
        {
            throw null;
        }

        public int[] GetGroupNumbers()
        {
            throw null;
        }

        public string GroupNameFromNumber(int i)
        {
            throw null;
        }

        public int GroupNumberFromName(string name)
        {
            throw null;
        }

        public bool IsMatch(string input)
        {
            return IsMatch(input, startat: 0);
        }

        public bool IsMatch(string input, int startat)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (startat < 0 || startat > input.Length) // .NET uses > not >=
                throw new ArgumentOutOfRangeException("startat");

            // only need a single match, so use match_data_create(1).
            
            // TODO - creating and freeing this match data accounts for a decent percentage
            // of time taken in IsMatch, but we don't really use the data.
            // However, match_data is not thread-safe, so we can't cache it unconditionally.
            // Maybe we can cache at most one on a Regex instance, and only create a new one if the cached
            // one is currently in use?
            IntPtr match_data = Interop.pcre2_match_data_create(1, IntPtr.Zero);
            try
            {
                int errorcode = Interop.pcre2_match(_code, input, new IntPtr(input.Length), new IntPtr(startat), options: 0, match_data, mcontext: IntPtr.Zero);

                if (errorcode == Interop.PCRE2_ERROR_NOMATCH)
                    return false;
                if (errorcode < 0)
                    throw new InvalidOperationException($"ERR{errorcode} {Interop.GetMessage(errorcode)}");

                return true;
            }
            finally
            { 
                Interop.pcre2_match_data_free(match_data);
            }
        }

        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.None);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return IsMatch(input, pattern, options, TimeSpan.MaxValue);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            var re = new Regex(pattern, options);
            return re.IsMatch(input);
        }

        public Match Match(string input)
        {
            return Match(input, startat: 0);
        }

        public Match Match(string input, int startat)
        {
            return Match(input, startat, input == null ? 0 : input.Length);
        }

        public Match Match(string input, int beginning, int length)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (beginning < 0 || beginning > input.Length)
                throw new ArgumentOutOfRangeException("beginning");
            if (length < 0 || length > input.Length)
                throw new ArgumentOutOfRangeException("length");

            IntPtr match_data = Interop.pcre2_match_data_create_from_pattern(_code, IntPtr.Zero);
            try
            {
                // TODO (eerhardt) - use matchResult to find out the highest matching group
                int matchResult = Interop.pcre2_match(_code, input, new IntPtr(length), new IntPtr(beginning), options: 0, match_data, mcontext: IntPtr.Zero);

                if (matchResult == Interop.PCRE2_ERROR_NOMATCH)
                    return RegularExpressions.Match.Empty;
                if (matchResult < 0)
                    throw new InvalidOperationException($"ERR{matchResult} {Interop.GetMessage(matchResult)}");

                int ovc = Interop.pcre2_get_ovector_count(match_data);
                IntPtr ov = Interop.pcre2_get_ovector_pointer(match_data);

                var entries = new int[ovc * 2]; // ovc is the number of pairs
                for (int i = 0; i < entries.Length; i++)
                {
                    entries[i] = (int)Marshal.ReadIntPtr(ov + i * sizeof(IntPtr)); // cast to int, even though it's a size_t
                }

                // ovector is an array of pairs of ints, counting code units,
                // each [start, end)
                // ie., end is one code unit after the end
                // first pair is the entire match, subsequent pairs are the capturing groups if any

                Match result = new Match(input, entries, success: true);

                return result;
            }
            finally
            {
                Interop.pcre2_match_data_free(match_data);
            }
        }

        public static Match Match(string input, string pattern)
        {
            return Match(input, pattern, RegexOptions.None);
        }

        public static Match Match(string input, string pattern, RegexOptions options)
        {
            return Match(input, pattern, options, TimeSpan.MaxValue);
        }

        public static Match Match(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (pattern == null)
                throw new ArgumentNullException("pattern");

            throw null;
        }

        public MatchCollection Matches(string input)
        {
            return Matches(input, startat:0);
        }

        public MatchCollection Matches(string input, int startat)
        {
            throw null;
        }

        public static MatchCollection Matches(string input, string pattern)
        {
            return Matches(input, pattern, RegexOptions.None); 
        }

        public static MatchCollection Matches(string input, string pattern, RegexOptions options)
        {
            return Matches(input, pattern, options, TimeSpan.MaxValue);
        }

        public static int MatchCount(string input, string pattern, RegexOptions options)
        {
            return Matches(input, pattern, options).Count;
        }

        public static MatchCollection Matches(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (pattern == null)
                throw new ArgumentNullException("pattern");

            var re = new Regex(pattern, options);

            IntPtr match_data = IntPtr.Zero;
            int count = 0;
            try
            {
                match_data = Interop.pcre2_match_data_create_from_pattern(re._code, IntPtr.Zero);

                int startat = 0;
                while (true)
                {
                    int errorcode = Interop.pcre2_match(re._code, input, new IntPtr(input.Length), new IntPtr(startat), options: 0, match_data, mcontext: IntPtr.Zero);

                    if (errorcode == Interop.PCRE2_ERROR_NOMATCH)
                        break;
                  
                    if (errorcode < 0)
                        throw new InvalidOperationException($"ERR{errorcode} {Interop.GetMessage(errorcode)}");

                    int ovc = Interop.pcre2_get_ovector_count(match_data);
                    IntPtr ov = Interop.pcre2_get_ovector_pointer(match_data);

                    var entries = new int[ovc * 2]; // ovc is the number of pairs
                    for (int i = 0; i < ovc * 2; i++)
                    {
                        entries[i] = (int)Marshal.ReadIntPtr(ov + i * sizeof(IntPtr)); // cast to int, even though it's a size_t
                    }

                    // ovector is an array of pairs of ints, counting code units,
                    // each [start, end)
                    // ie., end is one code unit after the end
                    // first pair is the entire match, subsequent pairs are the capturing groups if any
                    startat = entries[1]; 
                    count++;
                }
            }
            finally
            {
                Interop.pcre2_match_data_free(match_data);
            }

            return new MatchCollection(count);
        }

        public string Replace(string input, string replacement)
        {
            return Replace(input, replacement, Int32.MaxValue);
        }

        public string Replace(string input, string replacement, int count)
        {
            return Replace(input, replacement, count, startat: 0);
        }

        public string Replace(string input, string replacement, int count, int startat)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (replacement == null)
                throw new ArgumentNullException("replacement");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            if (startat < 0 || startat > input.Length)
                throw new ArgumentOutOfRangeException("startat");

            IntPtr match_data = Interop.pcre2_match_data_create_from_pattern(_code, IntPtr.Zero);

            uint options = Interop.PCRE2_SUBSTITUTE_OVERFLOW_LENGTH;
            if (count == 0)
                return input;
            if (count > 1)
                options |= Interop.PCRE2_SUBSTITUTE_GLOBAL;

#if DEBUG
            int outlength = 1; // exercise buffer growth
#else
            int outlength = input.Length * 2;
#endif
            var outputbuffer = new char[outlength];
            int rc;
            while (true)
            {
                rc = Interop.pcre2_substitute(_code, input, new IntPtr(input.Length), new IntPtr(startat), options, match_data, mcontext: IntPtr.Zero, 
                                             replacement, new IntPtr(replacement.Length), outputbuffer, new IntPtr(&outlength));
                if (rc != Interop.PCRE2_ERROR_NOMEMORY)
                    break;

                outputbuffer = new char[outlength];
            }

            Debug.Assert(outlength <= outputbuffer.Length);
            if (rc < 0)
                throw new InvalidOperationException($"ERR{rc} {Interop.GetMessage(rc)}");
            if (rc > count) // PCRE does not support specifying count; ignore it unless it's less than actual count replaced
                throw new ArgumentOutOfRangeException($"PCRE does not support replacement count {count}, it replaced {rc}", "count");

            // TODO: free with pcre2_match_data_free

            return new string(outputbuffer, 0, outlength);
        }

        public static string Replace(string input, string pattern, string replacement)
        {
            return Replace(input, pattern, replacement, RegexOptions.None);
        }

        public static string Replace(string input, string pattern, string replacement, RegexOptions options)
        {
            return Replace(input, pattern, replacement, options, TimeSpan.MaxValue);
        }

        public static string Replace(string input, string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout)
        {
            Regex re = new Regex(pattern, options);

            return re.Replace(input, replacement); 
        }

        public static string Replace(string input, string pattern, MatchEvaluator evaluator)
        {
            throw null;
        }

        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options)
        {
            throw null;
        }

        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options, TimeSpan matchTimeout)
        {
            throw null;
        }

        public string Replace(string input, MatchEvaluator evaluator)
        {
            throw null;
        }

        public string Replace(string input, MatchEvaluator evaluator, int count)
        {
            throw null;
        }

        public string Replace(string input, MatchEvaluator evaluator, int count, int startat)
        {
            throw null;
        }

        public string[] Split(string input)
        {
            throw null;
        }

        public string[] Split(string input, int count)
        {
            throw null;
        }

        public string[] Split(string input, int count, int startat)
        {
            throw null;
        }

        public static string[] Split(string input, string pattern)
        {
            throw null;
        }

        public static string[] Split(string input, string pattern, RegexOptions options)
        {
            throw null;
        }

        public static string[] Split(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            throw null;
        }

        public override string ToString()
        {
            throw null;
        }

        public static string Unescape(string str)
        {
            throw null;
        }
    }

}
