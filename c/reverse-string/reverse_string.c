#include "reverse_string.h"
#include <stdlib.h>
#include <string.h>

char * reverse(const char * value) {
    int length = strlen(value);
    char * reversed = malloc(length * sizeof(char));

    for (int i = length - 1; i >= 0; --i) {
        reversed[length - 1 - i] = value[i];
    }

    return reversed;
}
