return {
  encode = function(s)
    local encoded = ''
    local count = 1
    local last = ''

    for i = 1, #s do
      local char = s:sub(i, i)

      if char == last then
        count = count + 1
      else
        if count > 1 then
          encoded = encoded .. count .. last
        else
          encoded = encoded .. last
        end
        count = 1
      end
      last = char
    end

    -- Handle the last character after the loop
    if count > 1 then
      encoded = encoded .. count .. last
    else
      encoded = encoded .. last
    end

    return encoded
  end,

  decode = function(s)
    local decoded = ''
    local count = ''

    for i = 1, #s do
      local char = s:sub(i, i)

      if tonumber(char) then
        count = count .. char
      else
        local count_as_number = tonumber(count)
        if count == '' or count_as_number == nil then
          decoded = decoded .. char
        else
          decoded = decoded .. string.rep(char, count_as_number)
          count = ''
        end
      end
    end

    return decoded
  end
}
