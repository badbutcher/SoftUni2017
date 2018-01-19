function wordsUppercase(input) {
    let result = input.split(/[^\w]+/).filter(Boolean);
    console.log(result.join(', ').trim().toUpperCase());
}

wordsUppercase('Hi, how are you?');