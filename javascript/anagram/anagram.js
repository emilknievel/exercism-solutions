export const findAnagrams = (word, candidates) => {
  return candidates.filter((c) =>
    c.toLowerCase() !== word.toLowerCase()).filter((c) =>
      c.toLowerCase().split('').sort().join('') ===
      word.toLowerCase().split('').sort().join('')
  );
};
