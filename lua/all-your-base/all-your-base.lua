local all_your_base = {}

all_your_base.convert = function(from_digits, from_base)
  return {
    to = function(to_base)
      if from_digits == {} then
        print('from_digits is empty')
        return { 0 }
      end
      if from_base < 2 then
        error('invalid input base')
      end
      if to_base < 2 then
        error('invalid output base')
      end

      local to_digits = {}
      local number = 0
      local digit_sum = 0

      for i = 1, #from_digits do
        if from_digits[i] < 0 then
          error('negative digits are not allowed')
        end
        if from_digits[i] >= from_base then
          error('digit out of range')
        end

        number = number * from_base + from_digits[i]
        digit_sum = digit_sum + from_digits[i]
      end

      if digit_sum == 0 then
        return { 0 }
      end

      while number > 0 do
        table.insert(to_digits, 1, number % to_base)
        number = math.floor(number / to_base)
      end

      return to_digits
    end,
  }
end
return all_your_base
