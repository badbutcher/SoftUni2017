function arithmephile(input) {
    let biggestSum = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < input.length; i++) {
        let number = Number(input[i]);
        if (0 <= number && number < 10) {
            let sum = 1;
            for (let j = i + 1; j <= i + number; j++) {
                sum *= input[j];
            }

            if (biggestSum < sum) {
                biggestSum = sum;
            }
        }
    }

    console.log(biggestSum);
}

arithmephile([18,
    42,
    19,
    36,
    1,
    -297,
    38,
    100,
    9,
    -249,
    -170,
    -18,
    -208,
    -11,
    -87,
    -90,
    -286,
    -27
]);

arithmephile([100,
    200,
    2,
    3,
    2,
    3,
    2,
    1,
    1
]);