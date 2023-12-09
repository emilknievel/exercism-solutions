local function assert_position_on_board(pos)
  assert(pos.row >= 0, 'queen must have a positive row')
  assert(pos.column >= 0, 'queen must have a positive column')
  assert(pos.row < 8, 'queen must have a row on board')
  assert(pos.column < 8, 'queen must have a column on board')
end

local function is_diagonal(pos1, pos2)
  return math.abs(pos1.row - pos2.row) == math.abs(pos1.column - pos2.column)
end

return function(pos)
  assert_position_on_board(pos)

  return {
    can_attack = function(other_pos)
      return pos.row == other_pos.row or pos.col == other_pos.col or is_diagonal(pos, other_pos)
    end,
  }
end
