// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Experimental.RegularExpressions
{
    // PCRE apparently does not support .NET's "capture" concept,
    // only returning the final capture of the group.
    //
    // PCRE: "If a capturing subpattern group is matched repeatedly within a single match operation, 
    //     it is the last portion of the subject that it matched that is returned."
    /*
     * For example given pattern "((\w)+)" and input "abc def"

        PCRE will produce
            Match 1 -- Groups: "abc", "c"
            Match 2 -- Groups: "def", "f"

        .NET will produce 
            Match 1 -- Groups: "abc" (Captures: "abc"), "c" (Captures: "a", "b", "c")
            Match 2 -- Groups: "def" (Captures: "def"), "f" (Captures: "d", "e", "f")
    */
    public class Capture
    {
        internal Capture(string text, int index, int endIndex)
        {
            Text = text;
            Index = index;
            EndIndex = endIndex;
        }

        /// <summary>
        /// Returns the position in the original string where the first character of
        /// captured substring was found.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// The exclusive end index of the captured substring.
        /// </summary>
        public int EndIndex { get; }

        /// <summary>
        /// Returns the length of the captured substring.
        /// </summary>
        public int Length => EndIndex - Index;

        public ReadOnlySpan<char> Value => Text.AsSpan(Index, Length);

        public override string ToString() => Value.ToString();

        /// <summary>
        /// The original string
        /// </summary>
        internal string Text { get; private protected set; }
    }
}
