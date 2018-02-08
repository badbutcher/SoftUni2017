function expedition(primary, secondary, targets, startingPoint) {
    let steps = 1;
    let primaryMatrixRows = primary.length;
    let primaryMatrixCols = primary[0].length;
    let secondaryMatrixRows = secondary.length;
    let secondaryMatrixCols = secondary[0].length;

    for (let target of targets) {
        modifyPrimary(target)
    }

    let currentPosition = [startingPoint[0], startingPoint[1]];
    let previousDirection = '';

    while (true) {
        let currentRow = currentPosition[0];
        let currentCol = currentPosition[1];
        if (currentRow + 1 < primaryMatrixRows && primary[currentRow + 1][currentCol] === 0 && previousDirection !== "up") {
            currentPosition = [currentRow + 1, currentCol];
            previousDirection = "down"
        }
        else if (currentCol + 1 < primaryMatrixCols && primary[currentRow][currentCol + 1] === 0 && previousDirection !== "left") {
            currentPosition = [currentRow, currentCol + 1];
            previousDirection = "right"
        }
        else if (currentRow > 0 && primary[currentRow - 1][currentCol] === 0 && previousDirection !== "down") {
            currentPosition = [currentRow - 1, currentCol];
            previousDirection = "up"
        }
        else if (currentCol > 0 && primary[currentRow][currentCol - 1] === 0 && previousDirection !== "right") {
            currentPosition = [currentRow, currentCol - 1];
            previousDirection = "left"
        }
        else {
            break
        }

        steps++
    }

    console.log(steps);
    definePosition(currentPosition);

    function modifyPrimary([targetRow, targetCol]) {
        for (let row = 0; row < secondaryMatrixRows; row++) {
            if (row + targetRow < primaryMatrixRows) {
                for (let col = 0; col < secondaryMatrixCols; col++) {
                    if (primary[targetRow + row][targetCol + col] !== undefined && secondary[row][col] === 1) {
                        primary[targetRow + row][targetCol + col] = primary[targetRow + row][targetCol + col] === 0 ? 1 : 0
                    }
                }
            }
        }
    }

    function definePosition([currentRow, currentCol]) {
        if (currentRow === 0) {
            console.log("Top")
        }
        else if (currentRow === primaryMatrixRows - 1) {
            console.log("Bottom")
        }
        else if (currentCol === 0) {
            console.log("Left")
        }
        else if (currentCol === primaryMatrixCols - 1) {
            console.log("Right")
        }
        else if (currentRow < primaryMatrixRows / 2 && currentCol >= primaryMatrixCols / 2) {
            console.log("Dead end 1")
        }
        else if (currentRow < primaryMatrixRows / 2 && currentCol < primaryMatrixCols / 2) {
            console.log("Dead end 2")
        }
        else if (currentRow >= primaryMatrixRows / 2 && currentCol < primaryMatrixCols / 2) {
            console.log("Dead end 3")
        }
        else if (currentRow >= primaryMatrixRows / 2 && currentCol >= primaryMatrixCols / 2) {
            console.log("Dead end 4")
        }
    }
}

expedition([[1, 1, 0, 1, 1, 1, 1, 0],
        [0, 1, 1, 1, 0, 0, 0, 1],
        [1, 0, 0, 1, 0, 0, 0, 1],
        [0, 0, 0, 1, 1, 0, 0, 1],
        [1, 0, 0, 1, 1, 1, 1, 1],
        [1, 0, 1, 1, 0, 1, 0, 0]],
    [[0, 1, 1],
        [0, 1, 0],
        [1, 1, 0]],
    [[1, 1],
        [2, 3],
        [5, 3]],
    [0, 2]
);