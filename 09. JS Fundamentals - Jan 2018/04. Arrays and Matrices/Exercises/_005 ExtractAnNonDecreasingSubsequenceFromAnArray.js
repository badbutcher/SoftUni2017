function extractAnNonDecreasingSubsequenceFromAnArray(input) {
    let biggest = input[0];
    let result = [biggest];
    for (let i = 1; i < input.length; i++) {
        if (Number(input[i]) >= biggest) {
            biggest = input[i];
            result.push(biggest);
        }
    }

    console.log(result.join('\n'));
}

extractAnNonDecreasingSubsequenceFromAnArray([
    '122',
    '3',
    '8',
    '4',
    '10',
    '12',
    '3',
    '2',
    '24'
]);