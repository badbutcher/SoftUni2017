function diagonalSums(matrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let row in matrix) {
        for (let col in matrix[0]) {
            if (row === col) {
               firstDiagonal += matrix[row][col];
            }
        }
    }

    console.log(firstDiagonal);
}

diagonalSums([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
);