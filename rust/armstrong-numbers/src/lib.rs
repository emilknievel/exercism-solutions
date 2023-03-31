pub fn is_armstrong_number(num: u32) -> bool {
    let num = num as u64;
    let mut sum: u64 = 0;

    let digits: Vec<u32> = num
        .to_string()
        .chars()
        .take_while(|c| c.is_numeric())
        .map(|c| c.to_digit(10).unwrap())
        .collect();

    for digit in &digits {
        sum = sum.wrapping_add(digit.pow(digits.len().try_into().unwrap()).into());
    }

    return num == sum;
}
