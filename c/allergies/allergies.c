#include "allergies.h"
#include <stdio.h>

bool is_allergic_to(const allergen_t allergen, const unsigned int score) {
    return score & (1 << allergen);
}

allergen_list_t get_allergens(const unsigned int score) {
    allergen_list_t list;
    list.count = 0;

    for (int i = 0; i < ALLERGEN_COUNT; ++i) {
        list.allergens[i] = is_allergic_to(i, score);
        if (list.allergens[i] > 0)
            ++list.count;
    }

    return list;
}
