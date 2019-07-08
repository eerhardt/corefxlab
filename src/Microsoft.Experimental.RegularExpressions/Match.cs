using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Experimental.RegularExpressions
{
    public partial class Match : Group
    {
        internal Match(bool success, string value)
        {
            Success = success;
            Value = value;
        }

        public static Match Empty { get { throw null; } }
        public virtual GroupCollection Groups { get { throw null; } }
        public Match NextMatch() { throw null; }
        public virtual string Result(string replacement) { throw null; }
        public static Match Synchronized(Match inner) { throw null; }
    }
}
