typedef signed char int8_t;
typedef short int16_t;
typedef int int32_t;
typedef long long int64_t;
typedef unsigned char uint8_t;
typedef unsigned short uint16_t;
typedef unsigned int uint32_t;
typedef unsigned long long uint64_t;
typedef signed char int_least8_t;
typedef short int_least16_t;
typedef int int_least32_t;
typedef long long int_least64_t;
typedef unsigned char uint_least8_t;
typedef unsigned short uint_least16_t;
typedef unsigned int uint_least32_t;
typedef unsigned long long uint_least64_t;
typedef signed char int_fast8_t;
typedef int int_fast16_t;
typedef int int_fast32_t;
typedef long long int_fast64_t;
typedef unsigned char uint_fast8_t;
typedef unsigned int uint_fast16_t;
typedef unsigned int uint_fast32_t;
typedef unsigned long long uint_fast64_t;
typedef long long intmax_t;
typedef unsigned long long uintmax_t;

// Opaque structs
struct pcre2_general_context_16;
struct pcre2_compile_context_16;
struct pcre2_match_context_16;
struct pcre2_convert_context_16;
struct pcre2_code_16;
struct pcre2_match_data_16;
struct pcre2_jit_stack_16;

typedef pcre2_jit_stack_16 *(*pcre2_jit_callback_16)(void *);

typedef struct pcre2_callout_block_16
{
    uint32_t version;
    uint32_t callout_number;
    uint32_t capture_top;
    uint32_t capture_last;
    size_t *offset_vector;
    uint16_t* mark;
    uint16_t* subject;
    size_t subject_length;
    size_t start_match;
    size_t current_position;
    size_t pattern_position;
    size_t next_item_length;
    size_t callout_string_offset;
    size_t callout_string_length;
    uint16_t* callout_string;
    uint32_t callout_flags;
} pcre2_callout_block_16;

typedef struct pcre2_callout_enumerate_block_16
{
    uint32_t version;
    size_t pattern_position;
    size_t next_item_length;
    uint32_t callout_number;
    size_t callout_string_offset;
    size_t callout_string_length;
    uint16_t* callout_string;
} pcre2_callout_enumerate_block_16;

        int pcre2_config_16(uint32_t, void *);
        pcre2_general_context_16 *pcre2_general_context_copy_16(pcre2_general_context_16 *);
        pcre2_general_context_16 *pcre2_general_context_create_16(void *(*)(size_t, void *), void(*)(void *, void *), void *);
        void pcre2_general_context_free_16(pcre2_general_context_16 *);
        pcre2_compile_context_16 *pcre2_compile_context_copy_16(pcre2_compile_context_16 *);
        pcre2_compile_context_16 *pcre2_compile_context_create_16(pcre2_general_context_16 *);
        void pcre2_compile_context_free_16(pcre2_compile_context_16 *);
        int pcre2_set_bsr_16(pcre2_compile_context_16 *, uint32_t);
        int pcre2_set_character_tables_16(pcre2_compile_context_16 *, const unsigned char *);
        int pcre2_set_compile_extra_options_16(pcre2_compile_context_16 *, uint32_t);
        int pcre2_set_max_pattern_length_16(pcre2_compile_context_16 *, size_t);
        int pcre2_set_newline_16(pcre2_compile_context_16 *, uint32_t);
        int pcre2_set_parens_nest_limit_16(pcre2_compile_context_16 *, uint32_t);
        int pcre2_set_compile_recursion_guard_16(pcre2_compile_context_16 *, int(*)(uint32_t, void *), void *);
        pcre2_convert_context_16 *pcre2_convert_context_copy_16(pcre2_convert_context_16 *);
        pcre2_convert_context_16 *pcre2_convert_context_create_16(pcre2_general_context_16 *);
        void pcre2_convert_context_free_16(pcre2_convert_context_16 *);
        int pcre2_set_glob_escape_16(pcre2_convert_context_16 *, uint32_t);
        int pcre2_set_glob_separator_16(pcre2_convert_context_16 *, uint32_t);
        int pcre2_pattern_convert_16(uint16_t*, size_t, uint32_t, uint16_t **, size_t *, pcre2_convert_context_16 *);
        void pcre2_converted_pattern_free_16(uint16_t *);
        pcre2_match_context_16 *pcre2_match_context_copy_16(pcre2_match_context_16 *);
        pcre2_match_context_16 *pcre2_match_context_create_16(pcre2_general_context_16 *);
        void pcre2_match_context_free_16(pcre2_match_context_16 *);
        int pcre2_set_callout_16(pcre2_match_context_16 *, int(*)(pcre2_callout_block_16 *, void *), void *);
        int pcre2_set_depth_limit_16(pcre2_match_context_16 *, uint32_t);
        int pcre2_set_heap_limit_16(pcre2_match_context_16 *, uint32_t);
        int pcre2_set_match_limit_16(pcre2_match_context_16 *, uint32_t);
        int pcre2_set_offset_limit_16(pcre2_match_context_16 *, size_t);
        int pcre2_set_recursion_limit_16(pcre2_match_context_16 *, uint32_t);
        int pcre2_set_recursion_memory_management_16(pcre2_match_context_16 *, void *(*)(size_t, void *), void(*)(void *, void *), void *);

pcre2_code_16 *pcre2_compile_16(uint16_t*, size_t, uint32_t, int *, size_t *, pcre2_compile_context_16 *);

void pcre2_code_free_16(pcre2_code_16 *);
        pcre2_code_16 *pcre2_code_copy_16(const pcre2_code_16 *);
        pcre2_code_16 *pcre2_code_copy_with_tables_16(const pcre2_code_16 *);
        int pcre2_pattern_info_16(const pcre2_code_16 *, uint32_t, void *);
        int pcre2_callout_enumerate_16(const pcre2_code_16 *, int(*)(pcre2_callout_enumerate_block_16 *, void *), void *);
        pcre2_match_data_16 *pcre2_match_data_create_16(uint32_t, pcre2_general_context_16 *);
pcre2_match_data_16 *pcre2_match_data_create_from_pattern_16(const pcre2_code_16 *, pcre2_general_context_16 *);
        int pcre2_dfa_match_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t, pcre2_match_data_16 *, pcre2_match_context_16 *, int *, size_t);
int pcre2_match_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t, pcre2_match_data_16 *, pcre2_match_context_16 *);
void pcre2_match_data_free_16(pcre2_match_data_16 *);
        uint16_t* pcre2_get_mark_16(pcre2_match_data_16 *);
        uint32_t pcre2_get_ovector_count_16(pcre2_match_data_16 *);
        size_t *pcre2_get_ovector_pointer_16(pcre2_match_data_16 *);
        size_t pcre2_get_startchar_16(pcre2_match_data_16 *);
        int pcre2_substring_copy_byname_16(pcre2_match_data_16 *, uint16_t*, uint16_t *, size_t *);
        int pcre2_substring_copy_bynumber_16(pcre2_match_data_16 *, uint32_t, uint16_t *, size_t *);
        void pcre2_substring_free_16(uint16_t *);
        int pcre2_substring_get_byname_16(pcre2_match_data_16 *, uint16_t*, uint16_t **, size_t *);
        int pcre2_substring_get_bynumber_16(pcre2_match_data_16 *, uint32_t, uint16_t **, size_t *);
        int pcre2_substring_length_byname_16(pcre2_match_data_16 *, uint16_t*, size_t *);
        int pcre2_substring_length_bynumber_16(pcre2_match_data_16 *, uint32_t, size_t *);
        int pcre2_substring_nametable_scan_16(const pcre2_code_16 *, uint16_t*, uint16_t* *, uint16_t* *);
        int pcre2_substring_number_from_name_16(const pcre2_code_16 *, uint16_t*);
        void pcre2_substring_list_free_16(uint16_t* *);
        int pcre2_substring_list_get_16(pcre2_match_data_16 *, uint16_t ***, size_t **);
        int32_t pcre2_serialize_encode_16(const pcre2_code_16 **, int32_t, uint8_t **, size_t *, pcre2_general_context_16 *);
        int32_t pcre2_serialize_decode_16(pcre2_code_16 **, int32_t, const uint8_t *, pcre2_general_context_16 *);
        int32_t pcre2_serialize_get_number_of_codes_16(const uint8_t *);
        void pcre2_serialize_free_16(uint8_t *);
        int pcre2_substitute_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t, pcre2_match_data_16 *, pcre2_match_context_16 *, uint16_t*, size_t, uint16_t *, size_t *);
        int pcre2_jit_compile_16(pcre2_code_16 *, uint32_t);
        int pcre2_jit_match_16(const pcre2_code_16 *, uint16_t*, size_t, size_t, uint32_t, pcre2_match_data_16 *, pcre2_match_context_16 *);
        void pcre2_jit_free_unused_memory_16(pcre2_general_context_16 *);
        pcre2_jit_stack_16 *pcre2_jit_stack_create_16(size_t, size_t, pcre2_general_context_16 *);
        void pcre2_jit_stack_assign_16(pcre2_match_context_16 *, pcre2_jit_callback_16, void *);
        void pcre2_jit_stack_free_16(pcre2_jit_stack_16 *);
int pcre2_get_error_message_16(int, uint16_t *, size_t);
        const uint8_t *pcre2_maketables_16(pcre2_general_context_16 *);


int main()
{
    int i = 1;
}