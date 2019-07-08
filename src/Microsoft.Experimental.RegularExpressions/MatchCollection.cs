using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Experimental.RegularExpressions
{
    public partial class MatchCollection : System.Collections.Generic.ICollection<Match>, System.Collections.Generic.IEnumerable<Match>, System.Collections.Generic.IList<Match>, System.Collections.Generic.IReadOnlyCollection<Match>, System.Collections.Generic.IReadOnlyList<Match>, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        private int _count;

        internal MatchCollection() { }
        internal MatchCollection(int count)
        {
            _count = count;
        }
        public int Count => _count;

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
}
