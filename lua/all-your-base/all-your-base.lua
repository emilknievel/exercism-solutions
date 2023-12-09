local all_your_base = {}

all_your_base.convert = function(from_digits, from_base)
  return {
    to = function(to_base)
      assert(from_digits ~= {}, 'from_digits is empty')
      assert(from_base >= 2, 'invalid input base')
      assert(to_base >= 2, 'invalid output base')

      local number = 0
      local digit_sum = 0

      for i = 1, #from_digits do
        assert(from_digits[i] >= 0, 'negative digits are not allowed')
        assert(from_digits[i] < from_base, 'digit out of range')

        number = number * from_base + from_digits[i]
        digit_sum = digit_sum + from_digits[i]
      end

      if digit_sum == 0 then
        return { 0 }
      end

      local to_digits = {}

      while number > 0 do
        table.insert(to_digits, 1, number % to_base)
        number = math.floor(number / to_base)
      end

      return to_digits
    end,
  }
end

return all_your_base
