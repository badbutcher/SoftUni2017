function wordsUppercase(input) {
    var separators = [',', ' ', '!', '?' ,'\''];

    var result = input.split(separators);
    console.log(result);
}

wordsUppercase('Hi, how are you?');