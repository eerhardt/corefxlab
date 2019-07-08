using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Experimental.RegularExpressions
{
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
}
