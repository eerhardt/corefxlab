using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Experimental.RegularExpressions
{
    public partial class Group : Capture
    {
        internal Group() { }
        public CaptureCollection Captures { get { throw null; } }
        public string Name { get { throw null; } }
        public bool Success
        {
            get;
            internal set;
        }
        public static Group Synchronized(Group inner) { throw null; }
    }
}
