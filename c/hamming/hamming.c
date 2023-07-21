#include "hamming.h"
#include <string.h>

int compute(const char *lhs, const char *rhs) {
    if (!lhs || !rhs)
        return -1;

    int distance = 0;
    for (; *lhs && *rhs; ++lhs, ++rhs) {
        if (*lhs != *rhs)
            ++distance;
    }

    return (*lhs || *rhs) ? -1 : distance;
}

// int compute(const char *lhs, const char *rhs) {
//     if (strlen(lhs) != strlen(rhs)) {
//         return -1;
//     }
//
//     int hamming = 0;
//     for (int i = 0; i < (int)strlen(lhs); ++i) {
//         if (lhs[i] != rhs[i]) {
//             ++hamming;
//         }
//     }
//
//     return hamming;
// }
