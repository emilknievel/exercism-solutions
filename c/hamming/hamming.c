#include "hamming.h"
#include <string.h>

int compute(const char *lhs, const char *rhs) {
    if (strlen(lhs) != strlen(rhs)) {
        return -1;
    }

    int hamming = 0;
    for (int i = 0; i < (int)strlen(lhs); ++i) {
        if (lhs[i] != rhs[i]) {
            ++hamming;
        }
    }

    return hamming;
}
