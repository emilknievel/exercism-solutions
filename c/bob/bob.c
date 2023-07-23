#include "bob.h"
#include <ctype.h>
#include <string.h>

char *hey_bob(char *greeting) {
    int yelling = is_yelling(greeting);

    if (is_question(greeting))
        return yelling ? "Calm down, I know what I'm doing!"
                       : "Sure.";

    if (yelling)
        return "Whoa, chill out!";

    if (is_silent(greeting))
        return "Fine. Be that way!";

    return "Whatever.";
}

int is_question(char *greeting) {
    int length = strlen(greeting);

    if (greeting[length - 1] == '?')
        return 1;

    for (int i = length - 1; i >= 0; --i) {
        if (isspace(greeting[i]))
            continue;

        if (greeting[i] == '?')
            return 1;

        break;
    }

    return 0;
}

int is_yelling(char *greeting) {
    int length = strlen(greeting);
    int non_alpha_count = 0;

    for (int i = 0; i < length; ++i) {
        if (isalpha(greeting[i])) {
            if (islower(greeting[i]))
                return 0;
        } else {
            ++non_alpha_count;
        }
    }

    if (non_alpha_count == length)
        return 0;

    return 1;
}

int is_silent(char *greeting) {
    int length = strlen(greeting);

    if (length == 0)
        return 1;

    for (int i = 0; i < length; ++i) {
        if (!isspace(greeting[i]))
            return 0;
    }

    return 1;
}
