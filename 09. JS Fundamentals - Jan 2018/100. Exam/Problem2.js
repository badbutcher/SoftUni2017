function problem2(input, commands) {//!!!! 90/100
    let matrix = [];
    let pollutedAreas = [];
    for (let i = 0; i < 5; i++) {
        let numbers = input[i].split(/\s+/g).map(Number);
        matrix.push(numbers);
    }

    for (let obj of commands) {
        let data = obj.split(/\s+/g);
        let type = data[0].toLowerCase();
        let index = Number(data[1]);

        if (type === 'breeze') {
            for (let i = 0; i < 5; i++) {
                matrix[index][i] -= 15;
            }
            matrix.filter(a => a[index] < 0).map(x => x[index] = 0);
        }
        else if (type === 'gale') {
            matrix.map(x => x[index] -= 20);
            matrix.filter(a => a[index] < 0).map(x => x[index] = 0);
        }
        else if (type === 'smog') {
            for (let i = 0; i < 5; i++) {
                matrix.map(x => x[i] += index);
            }
        }
    }

    for (let row = 0; row < 5; row++) {
        for (let col = 0; col < 5; col++) {
            if (matrix[row][col] >= 50) {
                let area = `[${row}-${col}]`;
                pollutedAreas.push(area);
            }
        }
    }

    if (pollutedAreas.length >= 1) {
        console.log(`Polluted areas: ${pollutedAreas.join(', ')}`);
    }
    else {
        console.log('No polluted areas');
    }
}

problem2([
        "5 7 72 14 4",
        "41 35 37 27 33",
        "23 16 27 42 12",
        "2 20 28 39 14",
        "16 34 31 10 24",
    ],
    ["breeze 1", "gale 2", "smog 25"]
);