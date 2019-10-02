// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Experimental.RegularExpressions
{
    public class Group : Capture
    {
        internal static readonly Group s_emptyGroup = new Group(string.Empty, 0, 0, false, string.Empty);

        internal Group(string text, int index, int endIndex, bool success, string name)
            : base(text, index, endIndex)
        {
            Success = success;
            Name = name;
        }

        public CaptureCollection Captures { get { throw null; } }
        public string Name { get; }
        public bool Success { get; }
        public static Group Synchronized(Group inner) { throw null; }
    }
}
