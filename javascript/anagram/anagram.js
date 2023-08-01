const getPermutations = (array) => {
  let permutations = [];

  if (array.length === 0) return [];
  if (array.length === 1) return [array];

  for (let i = 0; i < array.length; ++i) {
    const currentItem = array[i];
    const remainingItems = array.slice(0, i).concat(array.slice(i + 1));
    const remainingItemsPermuted = getPermutations(remainingItems);

    for (let j = 0; j < remainingItemsPermuted.length; ++j) {
      const permutedArray = [currentItem].concat(remainingItemsPermuted[j]);
      permutations.push(permutedArray);
    }
  }

  return permutations;
};

export const findAnagrams = (word, candidates) => {
  let array = Array.from(word);
  let permutations = getPermutations(array);
  let anagrams = permutations.map((e) => e.join('').toLowerCase());

  return candidates.filter(
    (c) =>
      c.toLowerCase() !== word.toLowerCase() &&
      anagrams.includes(c.toLowerCase())
  );
};
