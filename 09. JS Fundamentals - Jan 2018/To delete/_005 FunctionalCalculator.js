function functionalCalculator(input) {
    let numberOne = input[0];
    let numberTwo = input[1];
    let operator = input[2];

    switch (operator) {
        case '+':
            return sum(numberOne, numberTwo);
        case '-':
            return substract(numberOne, numberTwo);
        case '*':
            return mutiplay(numberOne, numberTwo);
        case '/':
            return divinde(numberOne, numberTwo);
        default:
            return 'error';
    }
}

function sum(numberOne, numberTwo) {
    return numberOne + numberTwo;
}

function substract(numberOne, numberTwo) {
    return numberOne - numberTwo;
}

function mutiplay(numberOne, numberTwo) {
    return numberOne * numberTwo;
}

function divinde(numberOne, numberTwo) {
    return numberOne / numberTwo;
}

console.log(functionalCalculator([2, 4, '+']));