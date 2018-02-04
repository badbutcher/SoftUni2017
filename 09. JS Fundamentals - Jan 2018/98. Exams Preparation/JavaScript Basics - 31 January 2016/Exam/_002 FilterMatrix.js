function filterMatrix(matrix) {
    let length = Number(matrix.pop());
    let joined = matrix.join(' ').split(' ');

    let currentCount = 1;
    for (let i = 0; i < joined.length; i++) {
        if (joined[i] === joined[i + 1]) {
            currentCount++;
            if (currentCount === length) {
                for (var k = i + 1; k > i + 1 - length; k--) {
                    joined[k] = false;
                }

                currentCount = 1;
            }
        }
        else {
            currentCount = 1;
        }
    }

    let result = [];
    let index = 0;
    for (let row = 0; row < matrix.length; row++) {
        let innerRow = [];
        for (let col = 0; col < matrix[row].split(' ').length; col++) {
            if (joined[index] !== false) {
                innerRow.push(joined[index])
            }

            index++;
        }

        result.push(innerRow);
    }

    for (let obj of result) {
        if (obj.length >= 1) {
            console.log(obj.join(' '));
        }
        else {
            console.log('(empty)');
        }
    }
}

filterMatrix(['1 2 3 4 5',
    'a 17 17 17 17 17',
    '17 17 17 18',
    '9 9 9 9 9 9 9 9 9 9 9 9',
    '1 9 9 9',
    '9 9 9',
    '9',
    '9',
    '9',
    '1209',
    '8']);

// filterMatrix(['3 3 3 2 5 9 9 9 9 1 2',
//     '1 1 1 1 1 2 5 8 1 1 7',
//     '7 7 1 2 3 5 7 4 4 1 2',
//     '2']
// );
// //
// filterMatrix(['2 1 1 1',
//     '1 1 1',
//     '3 7 3 3 1',
//     '2'
// ]);
//
// filterMatrix(['1 2 3 3',
//     '3 5 7 8',
//     '3 2 2 1',
//     '3'
// ]);
// filterMatrix(['2 1 1 1',
//     '1 1 1',
//     '3 7 3 3 1',
//     '2'
// ]);

// function filterMatrix(matrix) {
//     let length = Number(matrix.pop());
//     let joined = '';
//     for (let obj of matrix) {
//         joined += obj.split(' ').join('');
//     }
//
//     let count = 0;
//     for (let i = 0; i < joined.length; i++) {
//         let m = '';
//         for (let j = 0; j < length; j++) {
//             m += joined[j + i];
//         }
//
//         if (allEqual(m)) {
//             i += length - 1;
//             joined = joined.replace(m, 'Q'.repeat(length));
//             m = '';
//             count = 0;
//         }
//     }
//
//     let result = [];
//     let index = 0;
//     for (let row = 0; row < matrix.length; row++) {
//         let innerRow = [];
//         for (let col = 0; col < matrix[row].split(' ').length; col++) {
//             if (joined[index] !== 'Q') {
//                 innerRow.push(joined[index])
//             }
//
//             index++;
//         }
//
//         result.push(innerRow);
//     }
//
//     for (let obj of result) {
//         if (obj.length >= 1) {
//             console.log(obj.join(' '));
//         }
//         else {
//             console.log('(empty)');
//         }
//     }
//
//     function allEqual(input) {
//         return input.split('').every(char => char === input[0]);
//     }
// }
