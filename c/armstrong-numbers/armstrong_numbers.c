#include "armstrong_numbers.h"
#include <math.h>

bool is_armstrong_number(int candidate) {
    int no_digits = 0;
    int candidate_copy = candidate;

    // find out the number of digits
    while (candidate_copy > 0) {
        candidate_copy /= 10;
        ++no_digits;
    }

    int iteration = 0;
    int sum = 0;
    candidate_copy = candidate;

    // summarize
    while (candidate_copy > 0) {
        int digit = candidate_copy % 10;
        candidate_copy /= 10;
        sum += pow(digit, no_digits);
        ++iteration;
    }

    // compare
    return sum == candidate;
}
