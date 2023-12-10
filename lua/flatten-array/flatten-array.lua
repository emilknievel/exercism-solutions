local function flatten(input)
  local output = {}

  for _, value in ipairs(input) do
    if type(value) == 'table' then
      for _, inner_value in ipairs(flatten(value)) do
        table.insert(output, inner_value)
      end
    elseif value ~= nil then
      table.insert(output, value)
    end
  end

  return output
end

return flatten
