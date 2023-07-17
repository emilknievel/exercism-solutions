#include "isogram.h"
#include "ctype.h"
#include "stdlib.h"

bool is_isogram(const char *phrase) {
    if (phrase == NULL) {
        return false;
    }

    for (int i = 0; phrase[i] != '\0'; ++i) {
        for (int j = i; j >= 0; --j) {
            if (&phrase[i - j] != &phrase[i] &&
                tolower(phrase[i - j]) == tolower(phrase[i]) &&
                phrase[i] != '-' && phrase[i] != ' ') {
                return false;
            }
        }
    }

    return true;
}
