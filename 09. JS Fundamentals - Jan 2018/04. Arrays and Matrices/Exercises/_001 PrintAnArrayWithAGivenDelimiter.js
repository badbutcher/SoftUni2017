function printAnArrayWithAGivenDelimiter(input) {
    let delimiter = input[input.length - 1];
    let result = [];
    for (let i = 0; i < input.length - 1; i++) {
        result.push(input[i]);
    }

    console.log(result.join(delimiter));
}

printAnArrayWithAGivenDelimiter(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']);