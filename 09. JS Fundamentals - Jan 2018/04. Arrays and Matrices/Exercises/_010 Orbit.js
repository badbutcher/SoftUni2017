function orbit(input) {
    let rows = input[0];
    let cols = input[1];
    let xStart = input[2];
    let yStart = input[3];
    let matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
    }

    for (let i = rows - 1; i >= 0; i--) {
        for (let row = xStart - i; row < i + 1; row++) {
            for (let col = yStart - i; col < i + 1; col++) {

                matrix[row][col] = i;
            }
        }
    }

    console.log(matrix);
}

orbit([5, 5, 2, 2]);