local Character = {}

local function ability(scores)
  table.sort(scores, function(a, b) return a > b end)

  local total = 0
  for i = 1, 3 do
    total = total + scores[i]
  end

  return total
end

local function roll_dice()
  local scores = {}

  for _ = 1, 4 do
    local num = math.random(1, 6)
    table.insert(scores, num)
  end

  return scores
end

local function modifier(input)
  return math.floor((input - 10) / 2)
end

function Character:new(name)
  Character.name = name

  local abilities = {
    "strength",
    "dexterity",
    "constitution",
    "intelligence",
    "wisdom",
    "charisma",
  }

  for _, a in ipairs(abilities) do
    Character[a] = ability(roll_dice())
  end

  Character.hitpoints = 10 + modifier(Character.constitution)

  return Character
end

return {
  Character = Character,
  ability = ability,
  roll_dice = roll_dice,
  modifier = modifier
}
