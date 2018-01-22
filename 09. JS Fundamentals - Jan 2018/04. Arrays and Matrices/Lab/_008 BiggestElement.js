function biggestElement(matrix) {
    let biggest = Number.NEGATIVE_INFINITY;

    for (let row in matrix) {
        for (let col in matrix[0]) {
            if (matrix[row][col] >= biggest) {
                biggest = matrix[row][col];
            }
        }
    }

    console.log(biggest);
}

biggestElement([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
);