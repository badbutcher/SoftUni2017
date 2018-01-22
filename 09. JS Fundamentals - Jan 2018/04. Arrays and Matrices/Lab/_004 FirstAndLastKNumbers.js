function firstAndLastKNumbers(input) {
    let length = input[0];
    console.log(input.slice(1, length + 1));
    console.log(input.slice(input.length - length, input.length + length));
}

firstAndLastKNumbers([2,
    7, 8, 9]
);