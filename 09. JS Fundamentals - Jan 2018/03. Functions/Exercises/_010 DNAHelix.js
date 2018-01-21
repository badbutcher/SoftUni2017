function dnaHelix(input) {
    let text = 'ATCGTTAGGG';
    let textPos = 0;
    let count = 0;

    while (input > count) {
        if (count % 4 === 0) {
            console.log(`**${text[textPos]}${text[textPos + 1]}**`);
        }
        else if (count % 4 === 1) {
            console.log(`*${text[textPos]}--${[text[textPos + 1]]}*`);
        }
        else if (count % 4 === 2) {
            console.log(`${text[textPos]}----${[text[textPos + 1]]}`);
        }
        else if (count % 4 === 3) {
            console.log(`*${text[textPos]}--${[text[textPos + 1]]}*`);
        }

        textPos += 2;

        if (textPos >= 10) {
            textPos = 0;
        }

        count++;
    }
}

// function dnaHelix(input) {
//     let text = 'ATCGTTAGGG';
//     let count = 0;
//
//     for (let i = 0; i < input; i++) {
//         if (i % 4 === 0) {
//             console.log(`**${text[count % 10]}${text[count % 10 + 1]}**`);
//         }
//         else if (i % 4 === 1) {
//             console.log(`*${text[count % 10]}--${text[count % 10 + 1]}*`);
//         }
//         else if (i % 4 === 2) {
//             console.log(`${text[count % 10]}----${text[count % 10 + 1]}`);
//         }
//         else if (i % 4 === 3) {
//             console.log(`*${text[count % 10]}--${text[count % 10 + 1]}*`);
//         }
//
//         count += 2
//     }
// }

dnaHelix(10);