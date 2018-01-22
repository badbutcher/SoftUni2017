function printEveryNthElementFromAnArray(input) {
    let step = Number(input[input.length - 1]);
    for (let i = 0; i < input.length - 1; i++) {
        if (i % step === 0) {
            console.log(input[i]);
        }
    }
}

printEveryNthElementFromAnArray(['5',
    '20',
    '31',
    '4',
    '20',
    '2'
]);