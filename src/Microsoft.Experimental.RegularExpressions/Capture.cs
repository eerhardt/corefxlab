using System;
using System.Collections.Generic;
using System.Text;

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
    public partial class Capture
    {
        internal Capture() { }
        public int Index { get { throw null; } }
        public int Length { get { throw null; } }
        public string Value {
            get;
            internal set;
        }
        public override string ToString() { throw null; }
    }
}
