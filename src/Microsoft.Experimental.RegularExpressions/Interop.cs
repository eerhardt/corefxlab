using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

using size_t = System.IntPtr;

namespace Microsoft.Experimental.RegularExpressions
{
    // from PCRE2.h, with functions generated with PCRE2_CODE_UNIT_WIDTH=16
    internal partial class Interop
    {
        #region consts
        /* The following option bits can be passed to pcre2_compile(), pcre2_match(),
        or pcre2_dfa_match(). PCRE2_NO_UTF_CHECK affects only the function to which it
        is passed. Put these bits at the most significant end of the options word so
        others can be added next to them */

        internal const uint PCRE2_ANCHORED = 0x80000000u;
        internal const uint PCRE2_NO_UTF_CHECK = 0x40000000u;
        internal const uint PCRE2_ENDANCHORED = 0x20000000u;

        /* The following option bits can be passed only to pcre2_compile(). However,
        they may affect compilation, JIT compilation, and/or interpretive execution.
        The following tags indicate which:

        C   alters what is compiled by pcre2_compile()
        J   alters what is compiled by pcre2_jit_compile()
        M   is inspected during pcre2_match() execution
        D   is inspected during pcre2_dfa_match() execution
        */

        internal const uint PCRE2_ALLOW_EMPTY_CLASS = 0x00000001u;  /* C       */
        internal const uint PCRE2_ALT_BSUX = 0x00000002u;  /* C       */
        internal const uint PCRE2_AUTO_CALLOUT = 0x00000004u;  /* C       */
        internal const uint PCRE2_CASELESS = 0x00000008u;  /* C       */
        internal const uint PCRE2_DOLLAR_ENDONLY = 0x00000010u;  /*   J M D */
        internal const uint PCRE2_DOTALL = 0x00000020u;  /* C       */
        internal const uint PCRE2_DUPNAMES = 0x00000040u;  /* C       */
        internal const uint PCRE2_EXTENDED = 0x00000080u;  /* C       */
        internal const uint PCRE2_FIRSTLINE = 0x00000100u;  /*   J M D */
        internal const uint PCRE2_MATCH_UNSET_BACKREF = 0x00000200u;  /* C J M   */
        internal const uint PCRE2_MULTILINE = 0x00000400u;  /* C       */
        internal const uint PCRE2_NEVER_UCP = 0x00000800u;  /* C       */
        internal const uint PCRE2_NEVER_UTF = 0x00001000u;  /* C       */
        internal const uint PCRE2_NO_AUTO_CAPTURE = 0x00002000u;  /* C       */
        internal const uint PCRE2_NO_AUTO_POSSESS = 0x00004000u;  /* C       */
        internal const uint PCRE2_NO_DOTSTAR_ANCHOR = 0x00008000u;  /* C       */


        internal const uint PCRE2_NO_START_OPTIMIZE = 0x00010000u;  /*   J M D */
        internal const uint PCRE2_UCP = 0x00020000u;  /* C J M D */
        internal const uint PCRE2_UNGREEDY = 0x00040000u;  /* C       */
        internal const uint PCRE2_UTF = 0x00080000u;  /* C J M D */
        internal const uint PCRE2_NEVER_BACKSLASH_C = 0x00100000u;  /* C       */
        internal const uint PCRE2_ALT_CIRCUMFLEX = 0x00200000u;  /*   J M D */
        internal const uint PCRE2_ALT_VERBNAMES = 0x00400000u;  /* C       */
        internal const uint PCRE2_USE_OFFSET_LIMIT = 0x00800000u;  /*   J M D */
        internal const uint PCRE2_EXTENDED_MORE = 0x01000000u;  /* C       */
        internal const uint PCRE2_LITERAL = 0x02000000u;  /* C       */

        /* An additional compile options word is available in the compile context. */

        internal const uint PCRE2_EXTRA_ALLOW_SURROGATE_ESCAPES = 0x00000001u;  /* C */
        internal const uint PCRE2_EXTRA_BAD_ESCAPE_IS_LITERAL = 0x00000002u;  /* C */
        internal const uint PCRE2_EXTRA_MATCH_WORD = 0x00000004u;  /* C */
        internal const uint PCRE2_EXTRA_MATCH_LINE = 0x00000008u;  /* C */

        /* These are for pcre2_jit_compile(). */

        internal const uint PCRE2_JIT_COMPLETE = 0x00000001u;  /* For full matching */
        internal const uint PCRE2_JIT_PARTIAL_SOFT = 0x00000002u;
        internal const uint PCRE2_JIT_PARTIAL_HARD = 0x00000004u;

        /* These are for pcre2_match(), pcre2_dfa_match(), and pcre2_jit_match(). Note
        that PCRE2_ANCHORED and PCRE2_NO_UTF_CHECK can also be passed to these
        functions (though pcre2_jit_match() ignores the latter since it bypasses all
        sanity checks). */

        internal const uint PCRE2_NOTBOL = 0x00000001u;
        internal const uint PCRE2_NOTEOL = 0x00000002u;
        internal const uint PCRE2_NOTEMPTY = 0x00000004u;  /* ) These two must be kept */
        internal const uint PCRE2_NOTEMPTY_ATSTART = 0x00000008u;  /* ) adjacent to each other. */
        internal const uint PCRE2_PARTIAL_SOFT = 0x00000010u;
        internal const uint PCRE2_PARTIAL_HARD = 0x00000020u;

        /* These are additional options for pcre2_dfa_match(). */

        internal const uint PCRE2_DFA_RESTART = 0x00000040u;
        internal const uint PCRE2_DFA_SHORTEST = 0x00000080u;

        /* These are additional options for pcre2_substitute(), which passes any others
        through to pcre2_match(). */

        internal const uint PCRE2_SUBSTITUTE_GLOBAL = 0x00000100u;
        internal const uint PCRE2_SUBSTITUTE_EXTENDED = 0x00000200u;
        internal const uint PCRE2_SUBSTITUTE_UNSET_EMPTY = 0x00000400u;
        internal const uint PCRE2_SUBSTITUTE_UNKNOWN_UNSET = 0x00000800u;
        internal const uint PCRE2_SUBSTITUTE_OVERFLOW_LENGTH = 0x00001000u;

        /* A further option for pcre2_match(), not allowed for pcre2_dfa_match(),
        ignored for pcre2_jit_match(). */

        internal const uint PCRE2_NO_JIT = 0x00002000u;

        /* Options for pcre2_pattern_convert(). */

        internal const uint PCRE2_CONVERT_UTF = 0x00000001u;
        internal const uint PCRE2_CONVERT_NO_UTF_CHECK = 0x00000002u;
        internal const uint PCRE2_CONVERT_POSIX_BASIC = 0x00000004u;
        internal const uint PCRE2_CONVERT_POSIX_EXTENDED = 0x00000008u;
        internal const uint PCRE2_CONVERT_GLOB = 0x00000010u;
        internal const uint PCRE2_CONVERT_GLOB_NO_WILD_SEPARATOR = 0x00000030u;
        internal const uint PCRE2_CONVERT_GLOB_NO_STARSTAR = 0x00000050u;

        /* Newline and \R settings, for use in compile contexts. The newline values
        must be kept in step with values set in config.h and both sets must all be
        greater than zero. */

        internal const uint PCRE2_NEWLINE_CR = 1;
        internal const uint PCRE2_NEWLINE_LF = 2;
        internal const uint PCRE2_NEWLINE_CRLF = 3;
        internal const uint PCRE2_NEWLINE_ANY = 4;
        internal const uint PCRE2_NEWLINE_ANYCRLF = 5;
        internal const uint PCRE2_NEWLINE_NUL = 6;

        internal const uint PCRE2_BSR_UNICODE = 1;
        internal const uint PCRE2_BSR_ANYCRLF = 2;

        internal const int PCRE2_ZERO_TERMINATED = ~(int)0;
        internal const int PCRE2_UNSET = ~(int)0;

        /* Error codes for pcre2_compile(). Some of these are also used by
        pcre2_pattern_convert(). */

        internal const int PCRE2_ERROR_END_BACKSLASH = 101;
        internal const int PCRE2_ERROR_END_BACKSLASH_C = 102;
        internal const int PCRE2_ERROR_UNKNOWN_ESCAPE = 103;
        internal const int PCRE2_ERROR_QUANTIFIER_OUT_OF_ORDER = 104;
        internal const int PCRE2_ERROR_QUANTIFIER_TOO_BIG = 105;
        internal const int PCRE2_ERROR_MISSING_SQUARE_BRACKET = 106;
        internal const int PCRE2_ERROR_ESCAPE_INVALID_IN_CLASS = 107;
        internal const int PCRE2_ERROR_CLASS_RANGE_ORDER = 108;
        internal const int PCRE2_ERROR_QUANTIFIER_INVALID = 109;
        internal const int PCRE2_ERROR_INTERNAL_UNEXPECTED_REPEAT = 110;
        internal const int PCRE2_ERROR_INVALID_AFTER_PARENS_QUERY = 111;
        internal const int PCRE2_ERROR_POSIX_CLASS_NOT_IN_CLASS = 112;
        internal const int PCRE2_ERROR_POSIX_NO_SUPPORT_COLLATING = 113;
        internal const int PCRE2_ERROR_MISSING_CLOSING_PARENTHESIS = 114;
        internal const int PCRE2_ERROR_BAD_SUBPATTERN_REFERENCE = 115;
        internal const int PCRE2_ERROR_NULL_PATTERN = 116;
        internal const int PCRE2_ERROR_BAD_OPTIONS = 117;
        internal const int PCRE2_ERROR_MISSING_COMMENT_CLOSING = 118;
        internal const int PCRE2_ERROR_PARENTHESES_NEST_TOO_DEEP = 119;
        internal const int PCRE2_ERROR_PATTERN_TOO_LARGE = 120;
        internal const int PCRE2_ERROR_HEAP_FAILED = 121;
        internal const int PCRE2_ERROR_UNMATCHED_CLOSING_PARENTHESIS = 122;
        internal const int PCRE2_ERROR_INTERNAL_CODE_OVERFLOW = 123;
        internal const int PCRE2_ERROR_MISSING_CONDITION_CLOSING = 124;
        internal const int PCRE2_ERROR_LOOKBEHIND_NOT_FIXED_LENGTH = 125;
        internal const int PCRE2_ERROR_ZERO_RELATIVE_REFERENCE = 126;
        internal const int PCRE2_ERROR_TOO_MANY_CONDITION_BRANCHES = 127;
        internal const int PCRE2_ERROR_CONDITION_ASSERTION_EXPECTED = 128;
        internal const int PCRE2_ERROR_BAD_RELATIVE_REFERENCE = 129;
        internal const int PCRE2_ERROR_UNKNOWN_POSIX_CLASS = 130;
        internal const int PCRE2_ERROR_INTERNAL_STUDY_ERROR = 131;
        internal const int PCRE2_ERROR_UNICODE_NOT_SUPPORTED = 132;
        internal const int PCRE2_ERROR_PARENTHESES_STACK_CHECK = 133;
        internal const int PCRE2_ERROR_CODE_POINT_TOO_BIG = 134;
        internal const int PCRE2_ERROR_LOOKBEHIND_TOO_COMPLICATED = 135;
        internal const int PCRE2_ERROR_LOOKBEHIND_INVALID_BACKSLASH_C = 136;
        internal const int PCRE2_ERROR_UNSUPPORTED_ESCAPE_SEQUENCE = 137;
        internal const int PCRE2_ERROR_CALLOUT_NUMBER_TOO_BIG = 138;
        internal const int PCRE2_ERROR_MISSING_CALLOUT_CLOSING = 139;
        internal const int PCRE2_ERROR_ESCAPE_INVALID_IN_VERB = 140;
        internal const int PCRE2_ERROR_UNRECOGNIZED_AFTER_QUERY_P = 141;
        internal const int PCRE2_ERROR_MISSING_NAME_TERMINATOR = 142;
        internal const int PCRE2_ERROR_DUPLICATE_SUBPATTERN_NAME = 143;
        internal const int PCRE2_ERROR_INVALID_SUBPATTERN_NAME = 144;
        internal const int PCRE2_ERROR_UNICODE_PROPERTIES_UNAVAILABLE = 145;
        internal const int PCRE2_ERROR_MALFORMED_UNICODE_PROPERTY = 146;
        internal const int PCRE2_ERROR_UNKNOWN_UNICODE_PROPERTY = 147;
        internal const int PCRE2_ERROR_SUBPATTERN_NAME_TOO_LONG = 148;
        internal const int PCRE2_ERROR_TOO_MANY_NAMED_SUBPATTERNS = 149;
        internal const int PCRE2_ERROR_CLASS_INVALID_RANGE = 150;
        internal const int PCRE2_ERROR_OCTAL_BYTE_TOO_BIG = 151;
        internal const int PCRE2_ERROR_INTERNAL_OVERRAN_WORKSPACE = 152;
        internal const int PCRE2_ERROR_INTERNAL_MISSING_SUBPATTERN = 153;
        internal const int PCRE2_ERROR_DEFINE_TOO_MANY_BRANCHES = 154;
        internal const int PCRE2_ERROR_BACKSLASH_O_MISSING_BRACE = 155;
        internal const int PCRE2_ERROR_INTERNAL_UNKNOWN_NEWLINE = 156;
        internal const int PCRE2_ERROR_BACKSLASH_G_SYNTAX = 157;
        internal const int PCRE2_ERROR_PARENS_QUERY_R_MISSING_CLOSING = 158;
        /* Error= 159 is obsolete and should now never occur */
        internal const int PCRE2_ERROR_VERB_ARGUMENT_NOT_ALLOWED = 159;
        internal const int PCRE2_ERROR_VERB_UNKNOWN = 160;
        internal const int PCRE2_ERROR_SUBPATTERN_NUMBER_TOO_BIG = 161;
        internal const int PCRE2_ERROR_SUBPATTERN_NAME_EXPECTED = 162;
        internal const int PCRE2_ERROR_INTERNAL_PARSED_OVERFLOW = 163;
        internal const int PCRE2_ERROR_INVALID_OCTAL = 164;
        internal const int PCRE2_ERROR_SUBPATTERN_NAMES_MISMATCH = 165;
        internal const int PCRE2_ERROR_MARK_MISSING_ARGUMENT = 166;
        internal const int PCRE2_ERROR_INVALID_HEXADECIMAL = 167;
        internal const int PCRE2_ERROR_BACKSLASH_C_SYNTAX = 168;
        internal const int PCRE2_ERROR_BACKSLASH_K_SYNTAX = 169;
        internal const int PCRE2_ERROR_INTERNAL_BAD_CODE_LOOKBEHINDS = 170;
        internal const int PCRE2_ERROR_BACKSLASH_N_IN_CLASS = 171;
        internal const int PCRE2_ERROR_CALLOUT_STRING_TOO_LONG = 172;
        internal const int PCRE2_ERROR_UNICODE_DISALLOWED_CODE_POINT = 173;
        internal const int PCRE2_ERROR_UTF_IS_DISABLED = 174;
        internal const int PCRE2_ERROR_UCP_IS_DISABLED = 175;
        internal const int PCRE2_ERROR_VERB_NAME_TOO_LONG = 176;
        internal const int PCRE2_ERROR_BACKSLASH_U_CODE_POINT_TOO_BIG = 177;
        internal const int PCRE2_ERROR_MISSING_OCTAL_OR_HEX_DIGITS = 178;
        internal const int PCRE2_ERROR_VERSION_CONDITION_SYNTAX = 179;
        internal const int PCRE2_ERROR_INTERNAL_BAD_CODE_AUTO_POSSESS = 180;
        internal const int PCRE2_ERROR_CALLOUT_NO_STRING_DELIMITER = 181;
        internal const int PCRE2_ERROR_CALLOUT_BAD_STRING_DELIMITER = 182;
        internal const int PCRE2_ERROR_BACKSLASH_C_CALLER_DISABLED = 183;
        internal const int PCRE2_ERROR_QUERY_BARJX_NEST_TOO_DEEP = 184;
        internal const int PCRE2_ERROR_BACKSLASH_C_LIBRARY_DISABLED = 185;
        internal const int PCRE2_ERROR_PATTERN_TOO_COMPLICATED = 186;
        internal const int PCRE2_ERROR_LOOKBEHIND_TOO_LONG = 187;
        internal const int PCRE2_ERROR_PATTERN_STRING_TOO_LONG = 188;
        internal const int PCRE2_ERROR_INTERNAL_BAD_CODE = 189;
        internal const int PCRE2_ERROR_INTERNAL_BAD_CODE_IN_SKIP = 190;
        internal const int PCRE2_ERROR_NO_SURROGATES_IN_UTF16 = 191;
        internal const int PCRE2_ERROR_BAD_LITERAL_OPTIONS = 192;
        internal const int PCRE2_ERROR_SUPPORTED_ONLY_IN_UNICODE = 193;
        internal const int PCRE2_ERROR_INVALID_HYPHEN_IN_OPTIONS = 194;


        /* "Expected" matching error codes: no match and partial match. */

        internal const int PCRE2_ERROR_NOMATCH = -1;
        internal const int PCRE2_ERROR_PARTIAL = -2;
        /* Error codes for UTF-8 validity checks */

        internal const int PCRE2_ERROR_UTF8_ERR1 = -3;
        internal const int PCRE2_ERROR_UTF8_ERR2 = -4;
        internal const int PCRE2_ERROR_UTF8_ERR3 = -5;
        internal const int PCRE2_ERROR_UTF8_ERR4 = -6;
        internal const int PCRE2_ERROR_UTF8_ERR5 = -7;
        internal const int PCRE2_ERROR_UTF8_ERR6 = -8;
        internal const int PCRE2_ERROR_UTF8_ERR7 = -9;
        internal const int PCRE2_ERROR_UTF8_ERR8 = -10;
        internal const int PCRE2_ERROR_UTF8_ERR9 = -11;
        internal const int PCRE2_ERROR_UTF8_ERR10 = -12;
        internal const int PCRE2_ERROR_UTF8_ERR11 = -13;
        internal const int PCRE2_ERROR_UTF8_ERR12 = -14;
        internal const int PCRE2_ERROR_UTF8_ERR13 = -15;
        internal const int PCRE2_ERROR_UTF8_ERR14 = -16;
        internal const int PCRE2_ERROR_UTF8_ERR15 = -17;
        internal const int PCRE2_ERROR_UTF8_ERR16 = -18;
        internal const int PCRE2_ERROR_UTF8_ERR17 = -19;
        internal const int PCRE2_ERROR_UTF8_ERR18 = -20;
        internal const int PCRE2_ERROR_UTF8_ERR19 = -21;
        internal const int PCRE2_ERROR_UTF8_ERR20 = -22;
        internal const int PCRE2_ERROR_UTF8_ERR21 = -23;
        /* Error codes for UTF-16 validity checks */

        internal const int PCRE2_ERROR_UTF16_ERR1 = -24;
        internal const int PCRE2_ERROR_UTF16_ERR2 = -25;
        internal const int PCRE2_ERROR_UTF16_ERR3 = -26;
        /* Error codes for UTF-32 validity checks */

        internal const int PCRE2_ERROR_UTF32_ERR1 = -27;
        internal const int PCRE2_ERROR_UTF32_ERR2 = -28;
        /* Miscellaneous error codes for pcre2[_dfa]_match(), substring extraction
        functions, context functions, and serializing functions. They are in numerical
        order. Originally they were in alphabetical order too, but now that PCRE2 is
        released, the numbers must not be changed. */

        internal const int PCRE2_ERROR_BADDATA = -29;
        internal const int PCRE2_ERROR_MIXEDTABLES = -30; /* Name was changed */
        internal const int PCRE2_ERROR_BADMAGIC = -31;
        internal const int PCRE2_ERROR_BADMODE = -32;
        internal const int PCRE2_ERROR_BADOFFSET = -33;
        internal const int PCRE2_ERROR_BADOPTION = -34;
        internal const int PCRE2_ERROR_BADREPLACEMENT = -35;
        internal const int PCRE2_ERROR_BADUTFOFFSET = -36;
        internal const int PCRE2_ERROR_CALLOUT = -37; /* Never used by PCRE2 itself */
        internal const int PCRE2_ERROR_DFA_BADRESTART = -38;
        internal const int PCRE2_ERROR_DFA_RECURSE = -39;
        internal const int PCRE2_ERROR_DFA_UCOND = -40;
        internal const int PCRE2_ERROR_DFA_UFUNC = -41;
        internal const int PCRE2_ERROR_DFA_UITEM = -42;
        internal const int PCRE2_ERROR_DFA_WSSIZE = -43;
        internal const int PCRE2_ERROR_INTERNAL = -44;
        internal const int PCRE2_ERROR_JIT_BADOPTION = -45;
        internal const int PCRE2_ERROR_JIT_STACKLIMIT = -46;
        internal const int PCRE2_ERROR_MATCHLIMIT = -47;
        internal const int PCRE2_ERROR_NOMEMORY = -48;
        internal const int PCRE2_ERROR_NOSUBSTRING = -49;
        internal const int PCRE2_ERROR_NOUNIQUESUBSTRING = -50;
        internal const int PCRE2_ERROR_NULL = -51;
        internal const int PCRE2_ERROR_RECURSELOOP = -52;
        internal const int PCRE2_ERROR_DEPTHLIMIT = -53;
        internal const int PCRE2_ERROR_RECURSIONLIMIT = -53; /* Obsolete synonym */
        internal const int PCRE2_ERROR_UNAVAILABLE = -54;
        internal const int PCRE2_ERROR_UNSET = -55;
        internal const int PCRE2_ERROR_BADOFFSETLIMIT = -56;
        internal const int PCRE2_ERROR_BADREPESCAPE = -57;
        internal const int PCRE2_ERROR_REPMISSINGBRACE = -58;
        internal const int PCRE2_ERROR_BADSUBSTITUTION = -59;
        internal const int PCRE2_ERROR_BADSUBSPATTERN = -60;
        internal const int PCRE2_ERROR_TOOMANYREPLACE = -61;
        internal const int PCRE2_ERROR_BADSERIALIZEDDATA = -62;
        internal const int PCRE2_ERROR_HEAPLIMIT = -63;
        internal const int PCRE2_ERROR_CONVERT_SYNTAX = -64;
        internal const int PCRE2_ERROR_INTERNAL_DUPMATCH = -65;


        #endregion
    }
}