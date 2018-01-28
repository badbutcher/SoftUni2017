function spiralMatrix(rows, cols) {
    let currentRow = 0;
    let currentCol = 0;
    let number = 1;
    let rotations = 0;
    let targetNum = rows * cols;
    let matrix = fillMatrixWithZeros(rows, cols);

    while (targetNum >= number) {
        // top row
        for (let idx = rotations; idx < cols - rotations; idx++) {
            matrix[currentRow][currentCol++] = number++;
        }

        // right col downwards
        currentCol--;
        for (let idx = ++currentRow; idx <= rows - 1 - rotations; idx++) {
            matrix[currentRow++][currentCol] = number++;
        }

        //bottom row leftwards
        currentRow--;
        for (let idx = --currentCol; idx >= rotations; idx--) {
            matrix[currentRow][currentCol--] = number++;
        }

        // left col upwards
        currentCol++;
        for (let idx = --currentRow; idx > rotations; idx--) {
            matrix[currentRow--][currentCol] = number++;
        }

        currentRow++;
        currentCol++;
        rotations++;
    }

    printMatrix(matrix);

    function printMatrix(matrix) {
        console.log(matrix.map(a => a.join(' ')).join('\n'));
    }

    function fillMatrixWithZeros(rows, cols) {
        let matrix = [];
        for (let i = 0; i < rows; i++) {
            matrix.push('0'.repeat(cols).split('').map(Number));
        }

        return matrix;
    }
}

spiralMatrix(5, 5);