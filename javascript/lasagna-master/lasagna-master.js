/// <reference path="./global.d.ts" />
// @ts-check

export function cookingStatus(timer) {
  if (timer === undefined) return 'You forgot to set the timer.';
  if (timer === 0) return 'Lasagna is done.';
  if (timer > 0) return 'Not done, please wait.';
}

const preparationTime = (layers, timePerLayer) =>
  timePerLayer ? layers.length * timePerLayer : layers.length * 2;

const quantities = (layers) => {
  let q = { noodles: 0, sauce: 0 };

  layers.forEach(layer => {
    if (layer === 'noodles') q.noodles += 50;
    else if (layer === 'sauce') q.sauce += 0.2;
  });

  return q;
};

const addSecretIngredient = (list1, list2) => {
  list2.push(list1.at(-1));
};

const scaleRecipe = (recipe, portionCount) => {
  let scaledRecipe = {};

  for (const [key, value] of Object.entries(recipe)) {
    scaledRecipe[key] = (value / 2) * portionCount;
  }

  return scaledRecipe;
};

export { preparationTime, quantities, addSecretIngredient, scaleRecipe };
