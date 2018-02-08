function thePyramidOfKingDjoser(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    let height = 1;

    let peek = 0;
    if (base % 2 === 0) {
        peek = 3;
    }
    else {
        peek = 2
    }

    while (base > peek) {
        let currentBaseSize = base * base;
        let stoneBase = Math.pow(base - 2, 2);

        if (height % 5 === 0) {
            let lapisBase = currentBaseSize - stoneBase;
            stone += stoneBase * increment;
            lapis += lapisBase * increment;
        }
        else {
            let marbleBase = currentBaseSize - stoneBase;
            stone += stoneBase * increment;
            marble += marbleBase * increment;
        }

        height++;
        base -= 2;
    }

    gold += base * base * increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(height * increment)}`);
}

// function thePyramidOfKingDjoser(size, increment) {
//     let totalRows = Math.ceil(size / 2);
//     let [stone, marble, lapis] = [0, 0, 0];
//     for (let i = 1; i <= totalRows - 1; i++) {
//         let currentStone = (size - 2) * (size - 2);
//         if (i % 5 === 0) {
//             lapis += size * size - currentStone
//         }
//         else {
//             marble += size * size - currentStone
//         }
//
//         stone += currentStone;
//         size -= 2
//     }
//
//     let gold = size * size;
//     console.log('Stone required: ' + Math.ceil(stone * increment));
//     console.log('Marble required: ' + Math.ceil(marble * increment));
//     console.log('Lapis Lazuli required: ' + Math.ceil(lapis * increment));
//     console.log('Gold required: ' + Math.ceil(gold * increment));
//     console.log('Final pyramid height: ' + Math.floor(totalRows * increment));
// }

thePyramidOfKingDjoser(22, 0.25);