function problem1(input) {
    let levaSum = 0;
    let bitcoins = 0;
    let firstBitcoinDay = 0;

    for (let i = 1; i <= input.length; i++) {
        let gold = Number(input[i - 1]);
        let levaForToday = gold;
        if (i % 3 === 0) {
            levaForToday -= (levaForToday * 30) / 100;
        }

        levaForToday *= 67.51;
        levaSum += levaForToday;

        while (levaSum >= 11949.16) {
            levaSum -= 11949.16;
            bitcoins++;
            if (firstBitcoinDay === 0) {
                firstBitcoinDay = i;
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoins}`);
    if (firstBitcoinDay !== 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }

    console.log(`Left money: ${levaSum.toFixed(2)} lv.`);
}

// problem1([100, 200, 300]);
// problem1([50, 100]);
problem1([3124.15, 504.212, 2511.124]);