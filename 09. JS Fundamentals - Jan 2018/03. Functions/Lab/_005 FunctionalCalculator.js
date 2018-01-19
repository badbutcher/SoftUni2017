function functionalCalculator(numberOne, numberTwo, operator) {
    switch (operator) {
        case '+':
            return sum(numberOne, numberTwo);
        case '-':
            return subtract(numberOne, numberTwo);
        case '*':
            return multiplier(numberOne, numberTwo);
        case '/':
            return divide(numberOne, numberTwo);
        default:
            return 'error';
    }

    function sum(numberOne, numberTwo) {
        return numberOne + numberTwo;
    }

    function subtract(numberOne, numberTwo) {
        return numberOne - numberTwo;
    }

    function multiplier(numberOne, numberTwo) {
        return numberOne * numberTwo;
    }

    function divide(numberOne, numberTwo) {
        return numberOne / numberTwo;
    }
}

console.log(functionalCalculator(2, 4, '+'));