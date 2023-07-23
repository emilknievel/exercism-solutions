#include "high_scores.h"
#include <stdlib.h>
#include <stdio.h>

int32_t latest(const int32_t *scores, size_t scores_len) {
    return scores[scores_len - 1];
}

int32_t personal_best(const int32_t *scores, size_t scores_len) {
    qsort((int32_t *)scores, scores_len, sizeof(int32_t), cmp_desc);
    return scores[0];
}

size_t personal_top_three(const int32_t *scores, size_t scores_len,
                          int32_t *output) {
    qsort((int32_t *)scores, scores_len, sizeof(int32_t), cmp_desc);
    for (int i = 0; i < 3; ++i) {
        if (i == (int)scores_len)
            break;
        output[i] = scores[i];
    }
    return scores_len < 3 ? scores_len : 3;
}

int cmp_desc(const void *a, const void *b) {
    int32_t arg1 = *(const int32_t*)a;
    int32_t arg2 = *(const int32_t*)b;

    return (arg2 - arg1);
}
