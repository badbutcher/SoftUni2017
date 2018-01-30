function buildAWall(wall) {
    let total = 0;
    let result = [];
    while (true) {
        let currentCubicYards = 0;
        for (let i = 0; i < wall.length; i++) {
            if (wall[i] < 30) {
                currentCubicYards += 195;
                wall[i]++;
            }
        }

        total += currentCubicYards;

        if (currentCubicYards !== 0) {
            result.push(currentCubicYards);
        }
        else {
            break;
        }
    }

    console.log(result.join(', '));
    console.log(`${Number(total * 1900)} pesos`);
}

buildAWall([21,
    25,
    28]);