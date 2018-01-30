function spiceMustFlow(startingYield) {
    let days = 0;
    let spice = 0;
    while (startingYield >= 100) {
        days++;
        spice += startingYield;
        startingYield -= 10;
        spice -= 26;
    }

    if (spice >= 26) {
        spice -= 26;
    }

    console.log(days);
    console.log(spice);
}

spiceMustFlow(200);