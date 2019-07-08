// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// ------------------------------------------------------------------------------
// Changes to this file must follow the http://aka.ms/api-review process.
// ------------------------------------------------------------------------------


namespace Microsoft.Experimental.RegularExpressions
{
    public partial class Capture
    {
        internal Capture() { }
        public int Index { get { throw null; } }
        public int Length { get { throw null; } }
        public string Value { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class CaptureCollection : System.Collections.Generic.ICollection<Capture>, System.Collections.Generic.IEnumerable<Capture>, System.Collections.Generic.IList<Capture>, System.Collections.Generic.IReadOnlyCollection<Capture>, System.Collections.Generic.IReadOnlyList<Capture>, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        internal CaptureCollection() { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsSynchronized { get { throw null; } }
        public Capture this[int i] { get { throw null; } }
        public object SyncRoot { get { throw null; } }
        public void CopyTo(System.Array array, int arrayIndex) { }
        public void CopyTo(Capture[] array, int arrayIndex) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        System.Collections.Generic.IEnumerator<Capture> System.Collections.Generic.IEnumerable<Capture>.GetEnumerator() { throw null; }
        int System.Collections.Generic.IList<Capture>.IndexOf(Capture item) { throw null; }
        void System.Collections.Generic.IList<Capture>.Insert(int index, Capture item) { }
        void System.Collections.Generic.IList<Capture>.RemoveAt(int index) { }
        Capture System.Collections.Generic.IList<Capture>.this[int index] { get { throw null; } set { } }
        void System.Collections.Generic.ICollection<Capture>.Add(Capture item) { }
        void System.Collections.Generic.ICollection<Capture>.Clear() { }
        bool System.Collections.Generic.ICollection<Capture>.Contains(Capture item) { throw null; }
        bool System.Collections.Generic.ICollection<Capture>.Remove(Capture item) { throw null; }
        int System.Collections.IList.Add(object value) { throw null; }
        void System.Collections.IList.Clear() { }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        void System.Collections.IList.Remove(object value) { }
        void System.Collections.IList.RemoveAt(int index) { }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
    }
    public partial class Group : Capture
    {
        internal Group() { }
        public CaptureCollection Captures { get { throw null; } }
        public string Name { get { throw null; } }
        public bool Success { get { throw null; } }
        public static Group Synchronized(Group inner) { throw null; }
    }
    public partial class GroupCollection : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.Generic.ICollection<Group>, System.Collections.Generic.IEnumerable<Group>, System.Collections.Generic.IList<Group>, System.Collections.Generic.IReadOnlyCollection<Group>, System.Collections.Generic.IReadOnlyList<Group>, System.Collections.IList, System.Collections.Generic.IReadOnlyDictionary<string, Group>
    {
        internal GroupCollection() { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsSynchronized { get { throw null; } }
        public Group this[int groupnum] { get { throw null; } }
        public Group this[string groupname] { get { throw null; } }
        public object SyncRoot { get { throw null; } }
        public void CopyTo(System.Array array, int arrayIndex) { }
        public void CopyTo(Group[] array, int arrayIndex) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        System.Collections.Generic.IEnumerator<Group> System.Collections.Generic.IEnumerable<Group>.GetEnumerator() { throw null; }
        int System.Collections.Generic.IList<Group>.IndexOf(Group item) { throw null; }
        void System.Collections.Generic.IList<Group>.Insert(int index, Group item) { }
        void System.Collections.Generic.IList<Group>.RemoveAt(int index) { }
        Group System.Collections.Generic.IList<Group>.this[int index] { get { throw null; } set { } }
        void System.Collections.Generic.ICollection<Group>.Add(Group item) { }
        void System.Collections.Generic.ICollection<Group>.Clear() { }
        bool System.Collections.Generic.ICollection<Group>.Contains(Group item) { throw null; }
        bool System.Collections.Generic.ICollection<Group>.Remove(Group item) { throw null; }
        int System.Collections.IList.Add(object value) { throw null; }
        void System.Collections.IList.Clear() { }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        void System.Collections.IList.Remove(object value) { }
        void System.Collections.IList.RemoveAt(int index) { }
        public bool ContainsKey(string key) { throw null; }
        public bool TryGetValue(string key, out Group value) { throw null; }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Group>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Group>>.GetEnumerator() { throw null; }

        public System.Collections.Generic.IEnumerable<string> Keys => throw null;
        public System.Collections.Generic.IEnumerable<Group> Values => throw null;
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
    }
    public partial class Match : Group
    {
        internal Match() { }
        public static Match Empty { get { throw null; } }
        public virtual GroupCollection Groups { get { throw null; } }
        public Match NextMatch() { throw null; }
        public virtual string Result(string replacement) { throw null; }
        public static Match Synchronized(Match inner) { throw null; }
    }
    public partial class MatchCollection : System.Collections.Generic.ICollection<Match>, System.Collections.Generic.IEnumerable<Match>, System.Collections.Generic.IList<Match>, System.Collections.Generic.IReadOnlyCollection<Match>, System.Collections.Generic.IReadOnlyList<Match>, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        internal MatchCollection() { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsSynchronized { get { throw null; } }
        public virtual Match this[int i] { get { throw null; } }
        public object SyncRoot { get { throw null; } }
        public void CopyTo(System.Array array, int arrayIndex) { }
        public void CopyTo(Match[] array, int arrayIndex) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        System.Collections.Generic.IEnumerator<Match> System.Collections.Generic.IEnumerable<Match>.GetEnumerator() { throw null; }
        int System.Collections.Generic.IList<Match>.IndexOf(Match item) { throw null; }
        void System.Collections.Generic.IList<Match>.Insert(int index, Match item) { }
        void System.Collections.Generic.IList<Match>.RemoveAt(int index) { }
        Match System.Collections.Generic.IList<Match>.this[int index] { get { throw null; } set { } }
        void System.Collections.Generic.ICollection<Match>.Add(Match item) { }
        void System.Collections.Generic.ICollection<Match>.Clear() { }
        bool System.Collections.Generic.ICollection<Match>.Contains(Match item) { throw null; }
        bool System.Collections.Generic.ICollection<Match>.Remove(Match item) { throw null; }
        int System.Collections.IList.Add(object value) { throw null; }
        void System.Collections.IList.Clear() { }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        void System.Collections.IList.Remove(object value) { }
        void System.Collections.IList.RemoveAt(int index) { }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
    }
    public delegate string MatchEvaluator(Match match);
    public partial class Regex : System.Runtime.Serialization.ISerializable
    {
        protected internal System.Collections.Hashtable caps;
        protected internal System.Collections.Hashtable capnames;
        protected internal int capsize;
        protected internal string[] capslist;
        protected internal RegexRunnerFactory factory;
        public static readonly System.TimeSpan InfiniteMatchTimeout;
        protected internal System.TimeSpan internalMatchTimeout;
        protected internal string pattern;
        protected internal RegexOptions roptions;
        protected Regex() { }
        protected Regex(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public Regex(string pattern) { }
        public Regex(string pattern, RegexOptions options) { }
        public Regex(string pattern, RegexOptions options, System.TimeSpan matchTimeout) { }
        public static int CacheSize { get { throw null; } set { } }
        protected System.Collections.IDictionary Caps { get { throw null; } set { } }
        protected System.Collections.IDictionary CapNames { get { throw null; } set { } }
        public System.TimeSpan MatchTimeout { get { throw null; } }
        public RegexOptions Options { get { throw null; } }
        public bool RightToLeft { get { throw null; } }
        public static string Escape(string str) { throw null; }
        public string[] GetGroupNames() { throw null; }
        public int[] GetGroupNumbers() { throw null; }
        public string GroupNameFromNumber(int i) { throw null; }
        public int GroupNumberFromName(string name) { throw null; }
        protected void InitializeReferences() { }
        public bool IsMatch(string input) { throw null; }
        public bool IsMatch(string input, int startat) { throw null; }
        public static bool IsMatch(string input, string pattern) { throw null; }
        public static bool IsMatch(string input, string pattern, RegexOptions options) { throw null; }
        public static bool IsMatch(string input, string pattern, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        public Match Match(string input) { throw null; }
        public Match Match(string input, int startat) { throw null; }
        public Match Match(string input, int beginning, int length) { throw null; }
        public static Match Match(string input, string pattern) { throw null; }
        public static Match Match(string input, string pattern, RegexOptions options) { throw null; }
        public static Match Match(string input, string pattern, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        public MatchCollection Matches(string input) { throw null; }
        public MatchCollection Matches(string input, int startat) { throw null; }
        public static MatchCollection Matches(string input, string pattern) { throw null; }
        public static MatchCollection Matches(string input, string pattern, RegexOptions options) { throw null; }
        public static MatchCollection Matches(string input, string pattern, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        public string Replace(string input, string replacement) { throw null; }
        public string Replace(string input, string replacement, int count) { throw null; }
        public string Replace(string input, string replacement, int count, int startat) { throw null; }
        public static string Replace(string input, string pattern, string replacement) { throw null; }
        public static string Replace(string input, string pattern, string replacement, RegexOptions options) { throw null; }
        public static string Replace(string input, string pattern, string replacement, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        public static string Replace(string input, string pattern, MatchEvaluator evaluator) { throw null; }
        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options) { throw null; }
        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        public string Replace(string input, MatchEvaluator evaluator) { throw null; }
        public string Replace(string input, MatchEvaluator evaluator, int count) { throw null; }
        public string Replace(string input, MatchEvaluator evaluator, int count, int startat) { throw null; }
        public string[] Split(string input) { throw null; }
        public string[] Split(string input, int count) { throw null; }
        public string[] Split(string input, int count, int startat) { throw null; }
        public static string[] Split(string input, string pattern) { throw null; }
        public static string[] Split(string input, string pattern, RegexOptions options) { throw null; }
        public static string[] Split(string input, string pattern, RegexOptions options, System.TimeSpan matchTimeout) { throw null; }
        void System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext context) { }
        public override string ToString() { throw null; }
        public static string Unescape(string str) { throw null; }
        protected bool UseOptionC() { throw null; }
        protected bool UseOptionR() { throw null; }
        protected internal static void ValidateMatchTimeout(System.TimeSpan matchTimeout) { }
    }
    public partial class RegexCompilationInfo
    {
        public RegexCompilationInfo(string pattern, RegexOptions options, string name, string fullnamespace, bool ispublic) { }
        public RegexCompilationInfo(string pattern, RegexOptions options, string name, string fullnamespace, bool ispublic, System.TimeSpan matchTimeout) { }
        public bool IsPublic { get; set; }
        public System.TimeSpan MatchTimeout { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public RegexOptions Options { get; set; }
        public string Pattern { get; set; }
    }
    public partial class RegexMatchTimeoutException : System.TimeoutException, System.Runtime.Serialization.ISerializable
    {
        public RegexMatchTimeoutException() { }
        protected RegexMatchTimeoutException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RegexMatchTimeoutException(string message) { }
        public RegexMatchTimeoutException(string message, System.Exception inner) { }
        public RegexMatchTimeoutException(string regexInput, string regexPattern, System.TimeSpan matchTimeout) { }
        public string Input { get { throw null; } }
        public System.TimeSpan MatchTimeout { get { throw null; } }
        public string Pattern { get { throw null; } }
        void System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext context) { }
    }
    [System.FlagsAttribute]
    public enum RegexOptions
    {
        Compiled = 8,
        CultureInvariant = 512,
        ECMAScript = 256,
        ExplicitCapture = 4,
        IgnoreCase = 1,
        IgnorePatternWhitespace = 32,
        Multiline = 2,
        None = 0,
        RightToLeft = 64,
        Singleline = 16,
    }
    public abstract partial class RegexRunner
    {
        protected internal int[] runcrawl;
        protected internal int runcrawlpos;
        protected internal Match runmatch;
        protected internal Regex runregex;
        protected internal int[] runstack;
        protected internal int runstackpos;
        protected internal string runtext;
        protected internal int runtextbeg;
        protected internal int runtextend;
        protected internal int runtextpos;
        protected internal int runtextstart;
        protected internal int[] runtrack;
        protected internal int runtrackcount;
        protected internal int runtrackpos;
        protected internal RegexRunner() { }
        protected void Capture(int capnum, int start, int end) { }
        protected static bool CharInClass(char ch, string charClass) { throw null; }
        protected static bool CharInSet(char ch, string @set, string category) { throw null; }
        protected void CheckTimeout() { }
        protected void Crawl(int i) { }
        protected int Crawlpos() { throw null; }
        protected void DoubleCrawl() { }
        protected void DoubleStack() { }
        protected void DoubleTrack() { }
        protected void EnsureStorage() { }
        protected abstract bool FindFirstChar();
        protected abstract void Go();
        protected abstract void InitTrackCount();
        protected bool IsBoundary(int index, int startpos, int endpos) { throw null; }
        protected bool IsECMABoundary(int index, int startpos, int endpos) { throw null; }
        protected bool IsMatched(int cap) { throw null; }
        protected int MatchIndex(int cap) { throw null; }
        protected int MatchLength(int cap) { throw null; }
        protected int Popcrawl() { throw null; }
        protected internal Match Scan(Regex regex, string text, int textbeg, int textend, int textstart, int prevlen, bool quick) { throw null; }
        protected internal Match Scan(Regex regex, string text, int textbeg, int textend, int textstart, int prevlen, bool quick, System.TimeSpan timeout) { throw null; }
        protected void TransferCapture(int capnum, int uncapnum, int start, int end) { }
        protected void Uncapture() { }
    }
    public abstract partial class RegexRunnerFactory
    {
        protected RegexRunnerFactory() { }
        protected internal abstract RegexRunner CreateInstance();
    }
}
