leap(Year) :-
    0 is Year mod 4,
    (\+(0 is Year mod 100) ; 0 is Year mod 400).
