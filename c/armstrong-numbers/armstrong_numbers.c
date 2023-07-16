#include "armstrong_numbers.h"
#include <math.h>

bool is_armstrong_number(int candidate) {
    int digit_count = calculate_digit_count(candidate);
    int sum = summarize_pow(candidate, digit_count);

    return sum == candidate;
}

int calculate_digit_count(int candidate) {
    int digit_count = 0;

    for (int i = candidate; i > 0; i /= 10) {
        ++digit_count;
    }

    return digit_count;
}

int summarize_pow(int num, int exponent) {
    int sum = 0;

    for (int i = num; i > 0; i /= 10) {
        int digit = i % 10;
        sum += pow(digit, exponent);
    }

    return sum;
}
