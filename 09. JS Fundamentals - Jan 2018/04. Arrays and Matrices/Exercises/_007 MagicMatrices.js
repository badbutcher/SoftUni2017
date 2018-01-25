function magicMatrices(matrix) {
    let magicNumbers = [];

    for (let row = 0; row < matrix.length; row++) {
        magicNumbers.push(matrix[row].reduce((a, b) => a + b));
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let colSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            colSum += matrix[row][col];
        }

        magicNumbers.push(colSum);
    }

    let result = Array.from(new Set(magicNumbers));
    if (result.length === 1) {
        return true;
    }
    else {
        return false;
    }
}

magicMatrices([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);