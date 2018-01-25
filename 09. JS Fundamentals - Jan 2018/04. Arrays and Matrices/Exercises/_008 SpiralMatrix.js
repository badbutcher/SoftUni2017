function spiralMatrix(input) {
    let rows = input[0];
    let cols = input[1];
    let number = 1;
    let matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
    }



    console.log(matrix);
}

spiralMatrix([5, 5]);