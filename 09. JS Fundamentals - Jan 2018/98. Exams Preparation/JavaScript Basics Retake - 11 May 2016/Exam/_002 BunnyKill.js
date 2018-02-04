function bunnyKill(input) {
    let matrix = [];
    let bombs = input.pop().split(' ');

    for (let i = 0; i < input.length; i++) {
        matrix[i] = input[i].split(' ').map(Number);
    }

    let dmgMade = 0;
    let bunniesKilled = 0;

    for (let obj of bombs) {
        let bomb = obj.split(',');
        let bombRow = Number(bomb[0]);
        let bombCol = Number(bomb[1]);
        let bombPower = Number(matrix[bombRow][bombCol]);
        if (bombPower > 0) {
            for (let row = 0; row < matrix.length; row++) {
                for (let col = 0; col < matrix[row].length; col++) {
                    if (row <= bombRow + 1 && row >= bombRow - 1 && col <= bombCol + 1 && col >= bombCol - 1) {
                        if (row === bombRow && col === bombCol && matrix[row][col] > 0) {
                            dmgMade += bombPower;
                            bunniesKilled++;
                        }

                        matrix[row][col] -= bombPower;
                    }
                }
            }
        }

        // console.log();
        // matrix.forEach(t => console.log(t.join(' ')))
    }

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] > 0) {
                dmgMade += matrix[row][col];
                bunniesKilled++;
            }
        }
    }

    console.log(dmgMade);
    console.log(bunniesKilled);
}

bunnyKill(['10 10 10',
    '10 10 10',
    '10 10 10',
    '0,0'
]);

console.log('\n---\n');

bunnyKill(['5 10 15 20',
    '10 10 10 10',
    '10 15 10 10',
    '10 10 10 10',
    '2,2 0,1'
]);