using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Experimental.RegularExpressions
{
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
}
