// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;

namespace Microsoft.Experimental.RegularExpressions
{
    public class Match : Group
    {
        internal GroupCollection _groupCollection;
        internal int[] _groups;

        internal Match(string text, int[] groups, bool success)
            : base(text,
                  index: groups.Length > 1 ? groups[0] : 0,
                  endIndex: groups.Length > 1 ? groups[1] : 0,
                  success,
                  name: "0")
        {
            Debug.Assert(groups.Length % 2 == 0, "Groups need to come in pairs.");

            _groups = groups;
        }

        public static Match Empty { get; } = new Match(null, new int[2], success: false);
        public virtual GroupCollection Groups
        {
            get
            {
                return _groupCollection ??
                    (_groupCollection = new GroupCollection(this));
            }
        }
        public Match NextMatch() { throw null; }
        public virtual string Result(string replacement) { throw null; }
        public static Match Synchronized(Match inner) { throw null; }
    }
}
