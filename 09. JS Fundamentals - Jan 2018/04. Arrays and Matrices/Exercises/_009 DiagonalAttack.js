function diagonalAttack(inputMatrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    let matrix = [];

    for (let i = 0; i < inputMatrix.length; i++) {
        matrix.push((inputMatrix[i].split(' ').map(Number)));
    }

    for (let row = 0; row < matrix.length; row++) {
        firstDiagonal += Number(matrix[row][row]);
        secondDiagonal += Number(matrix[row][matrix.length - row - 1]);
    }

    if (firstDiagonal !== secondDiagonal) {
        print(inputMatrix)
    }
    else {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row !== col && col !== matrix[row].length - row - 1) {
                    matrix[row][col] = firstDiagonal;
                }
            }
        }

        print(matrix);
    }

    function print(matrix) {
        for (let value of matrix) {
            console.log(value.join(' '));
        }
    }
}

diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);