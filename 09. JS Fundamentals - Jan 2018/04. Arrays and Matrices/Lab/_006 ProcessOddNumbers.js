function processOddNumbers(input) {
    let result = [];
    for (let i = input.length - 1; i >= 0; i--) {
        if (i % 2 !== 0) {
            result.push(input[i] * 2);
        }
    }

    console.log(result.join(' '));
}

processOddNumbers([10, 15, 20, 25]);