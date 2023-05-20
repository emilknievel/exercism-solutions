abbreviate(Sentence, Acronym) :-
    % we have a set of words split like so:
    split_string(Sentence, " -", " -_.,'", Words),

    % then we put the first letter of every word into a list:
    maplist(first_letter, Words, AcronymLetterList),

    % append them:
    string_chars(AcronymString, AcronymLetterList),

    % and turn the resulting acronym string into upper case:
    string_upper(AcronymString, Acronym).

first_letter(Word, FirstLetter) :-
    % divide word into letters and take first one:
    string_chars(Word, [FirstLetter|_]).
