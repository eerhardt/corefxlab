// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.Experimental.RegularExpressions
{
    public partial class GroupCollection : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.Generic.ICollection<Group>, System.Collections.Generic.IEnumerable<Group>, System.Collections.Generic.IList<Group>, System.Collections.Generic.IReadOnlyCollection<Group>, System.Collections.Generic.IReadOnlyList<Group>, System.Collections.IList, System.Collections.Generic.IReadOnlyDictionary<string, Group>
    {
        private readonly Match _match;

        // cache of Group objects fed to the user
        private Group[] _groups;

        internal GroupCollection(Match match)
        {
            _match = match;
        }

        public int Count => _match._groups.Length / 2;
        public bool IsReadOnly { get { throw null; } }
        public bool IsSynchronized { get { throw null; } }
        public Group this[int groupnum] => GetGroup(groupnum);

        private Group GetGroup(int groupnum)
        {
            if (groupnum < Count && groupnum >= 0)
            {
                return GetGroupImpl(groupnum);
            }

            return Group.s_emptyGroup;
        }

        /// <summary>
        /// Caches the group objects
        /// </summary>
        private Group GetGroupImpl(int groupnum)
        {
            if (groupnum == 0)
                return _match;

            // Construct all the Group objects the first time GetGroup is called

            if (_groups == null)
            {
                _groups = new Group[Count - 1];
                for (int i = 0; i < _groups.Length; i++)
                {
                    // TODO (eerhardt) string groupname = _match._regex.GroupNameFromNumber(i + 1);
                    string groupname = string.Empty;
                    _groups[i] =
                        new Group(_match.Text, _match._groups[i], _match._groups[i + 1], success: true, groupname);
                }
            }

            return _groups[groupnum - 1];
        }

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
