armstrong_number(N) :-
    % count the number of digits,
    atom_length(N, DigitCount),

    % separate number into digit chars,
    number_chars(N, DigitChars),

    % convert chars to digits,
    maplist(atom_number, DigitChars, Digits),

    % raise each digit with no. of digits,
    pow_list(Digits, DigitCount, PowDigits),

    % calculate sum of numbers.
    sum_list(PowDigits, Sum),

    N is Sum.

pow_list([], _, []).
pow_list([X|Xs], Number, Result) :-
     X1 is X ** Number,
     Result = [X1|NewXs],
     pow_list(Xs, Number, NewXs).
