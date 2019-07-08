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
        // These are all opaque structs
        //struct pcre2_general_context_16;
        //struct pcre2_compile_context_16;
        //struct pcre2_match_context_16;
        //struct pcre2_convert_context_16;
        //struct pcre2_code_16;
        //struct pcre2_match_data_16;
        //struct pcre2_jit_stack_16;

        // http://www.pcre.org/pcre2.txt

        // pcre2_code_16 *pcre2_compile_16(uint16_t*, size_t, uint32_t, int *, size_t *, pcre2_compile_context_16 *);
        // pcre2_code_16* pcre2_compile_16(uint16_t* pattern, size_t length, uint32_t options, int* errorcode, size_t* erroroffset, pcre2_compile_context_16* ccontext);
        // pcre2_code_16* pcre2_compile(PCRE2_SPTR, PCRE2_SIZE, uint32_t, int *, PCRE2_SIZE *, pcre2_compile_context*);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_compile_16")]
        internal static unsafe extern IntPtr pcre2_compile([MarshalAs(UnmanagedType.LPWStr)] string pattern, size_t length, uint options, int* errorcode, IntPtr erroroffset, IntPtr ccontext);

        // int pcre2_jit_compile(pcre2_code *code, uint32_t options);
        [DllImport("pcre2-16d", EntryPoint = "pcre2_jit_compile_16")]
        internal static unsafe extern int pcre2_jit_compile(IntPtr code, uint options);

        // int pcre2_get_error_message_16(int, uint16_t *, size_t);
        // int pcre2_get_error_message(int, PCRE2_UCHAR *, PCRE2_SIZE);
        // int pcre2_get_error_message(int errorcode, PCRE2_UCHAR *buffer, PCRE2_SIZE bufflen);
        [DllImport("pcre2-16d", CharSet = CharSet.Unicode, EntryPoint = "pcre2_get_error_message_16")]
        private static unsafe extern int pcre2_get_error_message(int errorcode, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] buffer, size_t bufflen);

        // int pcre2_substitute(const pcre2_code *code, PCRE2_SPTR subject, PCRE2_SIZE length, PCRE2_SIZE startoffset, uint32_t options,
        //        pcre2_match_data *match_data, pcre2_match_context *mcontext, PCRE2_SPTR replacement, PCRE2_SIZE rlength, PCRE2_UCHAR *\fIoutputbuffer\zfP, PCRE2_SIZE *outlengthptr);
        // int pcre2_substitute_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t,
        //        pcre2_match_data_16 *, pcre2_match_context_16 *, uint16_t*, size_t, uint16_t *, size_t *)
        //    pcre2_substitute(const pcre2_code*, PCRE2_SPTR, PCRE2_SIZE, PCRE2_SIZE, \
        //uint32_t, pcre2_match_data*, pcre2_match_context*, PCRE2_SPTR, \
        //PCRE2_SIZE, PCRE2_UCHAR*, PCRE2_SIZE*)
        [DllImport("pcre2-16d", CharSet = CharSet.Unicode, EntryPoint = "pcre2_substitute_16")]
        internal static unsafe extern int pcre2_substitute(IntPtr code,
                                                   [MarshalAs(UnmanagedType.LPWStr)] string subject, size_t length, size_t startoffset,
                                                   uint options, IntPtr match_data, IntPtr mcontext,
                                                   [MarshalAs(UnmanagedType.LPWStr)] string replacement, size_t rlength,
                                                   char[] outputbuffer, IntPtr outlengthptr);

        // pcre2_match_data_16 *pcre2_match_data_create_from_pattern_16(const pcre2_code_16 *, pcre2_general_context_16 *);
        // pcre2_match_data *pcre2_match_data_create_from_pattern(const pcre2_code*,pcre2_general_context*);
        // pcre2_match_data *pcre2_match_data_create_from_pattern(const pcre2_code* code, pcre2_general_context *gcontext);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_match_data_create_from_pattern_16")]
        internal static unsafe extern IntPtr pcre2_match_data_create_from_pattern(IntPtr pcre2_code, IntPtr gccontext);

        // int pcre2_match_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t, pcre2_match_data_16 *, pcre2_match_context_16 *);
        // int pcre2_match(const pcre2_code*, PCRE2_SPTR, PCRE2_SIZE, PCRE2_SIZE, uint32_t, pcre2_match_data*, pcre2_match_context*);
        // int pcre2_match(const pcre2_code* code, PCRE2_SPTR subject, PCRE2_SIZE length, PCRE2_SIZE startoffset,
        //                 uint32_t options, pcre2_match_data *match_data, pcre2_match_context* mcontext);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_match_16")]
        internal static unsafe extern int pcre2_match(IntPtr code, [MarshalAs(UnmanagedType.LPWStr)] string subject, size_t length, size_t startoffset, uint options, IntPtr match_data, IntPtr mcontext);

        // uint32_t pcre2_get_ovector_count(pcre2_match_data *match_data);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_get_ovector_count_16")]
        internal static unsafe extern int pcre2_get_ovector_count(IntPtr match_data);

        // PCRE2_SIZE* pcre2_get_ovector_pointer(pcre2_match_data* match_data);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_get_ovector_pointer_16")]
        internal static unsafe extern IntPtr pcre2_get_ovector_pointer(IntPtr match_data);

        // void pcre2_match_data_free(pcre2_match_data *match_data);
        [DllImport("pcre2-16d", CharSet = CharSet.Ansi, EntryPoint = "pcre2_match_data_free_16")]
        internal static unsafe extern void pcre2_match_data_free(IntPtr match_data);

        internal static string GetMessage(int errorcode)
        {
            var buffer = new char[256];
            int len = Interop.pcre2_get_error_message(errorcode, buffer, new IntPtr(buffer.Length));
            if (len == Interop.PCRE2_ERROR_BADDATA)
                return $"Unknown error {errorcode}";
            Debug.Assert(len != Interop.PCRE2_ERROR_NOMEMORY); // buffer too small

            return new string(buffer, 0, len);
        }
    }
}
