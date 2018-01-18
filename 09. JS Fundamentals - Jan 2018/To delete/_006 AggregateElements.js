function aggregateElements(input) {
    let result1 = sumNumbers(input);
    let result2 = sumInvert(input);
    let result3 = concat(input);

    console.log(result1);
    console.log(result2);
    console.log(result3);
}

function sumNumbers(input) {
    let sum = 0;
    for (let i = 0; i < input.length; i++) {
        sum += input[i];
    }

    return sum;
}

function sumInvert(input) {
    let sum = 0;
    for (let i = 0; i < input.length; i++) {
        sum += 1 / input[i];
    }

    return sum.toFixed(4);
}

function concat(input) {
    let concated = '';
    for (let i = 0; i < input.length; i++) {
        concated = ''.concat(concated, input[i]);
    }
    return concated;
}

aggregateElements([2, 4, 8, 16]);