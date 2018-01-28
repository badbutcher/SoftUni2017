function orbit(input) {
    let rows = input[0];
    let cols = input[1];
    let xStart = input[2];
    let yStart = input[3];
    let matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
    }

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            let formula = Math.max(Math.abs(row - xStart), Math.abs(col - yStart));
            matrix[row][col] = formula + 1;
        }
    }

    for (let value of matrix) {
        console.log(value.join(' '));
    }
}

orbit([5, 5, 2, 2]);