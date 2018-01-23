function equalNeighbors(matrix) {
    let count = 0;
    for (let row = 0; row < matrix.length - 1; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] === matrix[row][col + 1]) {
                count++;
            }

            if (matrix[row][col] === matrix[row + 1][col]) {
                count++;
            }

            if (row === matrix.length - 2 && matrix[row + 1][col] === matrix[row + 1][col + 1]) {
                count++
            }
        }
    }

    console.log(count);
}

equalNeighbors(
    [
        ['3', '3', '5', '7', '4'],
        ['4', '0', '5', '3', '4'],
        ['2', '5', '5', '4', '2']
    ]
);