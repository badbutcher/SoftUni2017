function jansNotation(input) {
    let numbers = [];
    let operations = [];

    for (let value of input) {
        if (Number.isInteger(value)) {
            numbers.push(value)
        }
        else {
            operations.push(value)
        }

        if (numbers.length >= 2 && operations.length >= 1) {
            let numberTwo = numbers.pop();
            let numberOne = numbers.pop();
            let operation = operations.shift();

            switch (operation) {
                case '+':
                    numbers.push(sum(numberOne, numberTwo));
                    break;
                case '-':
                    numbers.push(subtract(numberOne, numberTwo));
                    break;
                case '*':
                    numbers.push(multiplier(numberOne, numberTwo));
                    break;
                case '/':
                    numbers.push(divide(numberOne, numberTwo));
                    break;
                default:
                    return 'error';
            }
        }
    }

    if (numbers.length > operations.length + 1) {
        console.log('Error: too many operands!');
    }
    else if (numbers.length <= operations.length) {
        console.log('Error: not enough operands!');
    }
    else {
        console.log(numbers[0]);
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

// function jansNotation(arr) {
//     let numbers = [];
//     for (let i = 0; i < arr.length; i++) {
//         let current = arr[i];
//         if (typeof current === 'number') {
//             numbers.push(current)
//         }
//         else {
//             if (numbers.length > 1) {
//                 let num1 = numbers.pop();
//                 let num2 = numbers.pop();
//                 switch (current) {
//                     case "+":
//                         numbers.push(num2 + num1);
//                         break;
//                     case "-":
//                         numbers.push(num2 - num1);
//                         break;
//                     case "*":
//                         numbers.push(num2 * num1);
//                         break;
//                     case "/":
//                         numbers.push(num2 / num1);
//                         break;
//                     default:
//                         break
//                 }
//             }
//             else {
//                 console.log('Error: not enough operands!');
//                 return
//             }
//         }
//     }
//     numbers.length > 1 ? console.log('Error: too many operands!') : console.log(numbers[0])
// }

jansNotation([-1,
    1,
    '+',
    101,
    '*',
    18,
    '+',
    3,
    '/']
);