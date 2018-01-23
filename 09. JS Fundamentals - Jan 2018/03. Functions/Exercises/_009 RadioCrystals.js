function radioCrystals(input) {
    let target = input[0];
    let stage = 1;
    let actions = 0;

    function wash(crystal) {
        console.log('Transporting and washing');
        crystal = Math.floor(crystal);
        actions = 0;
        return crystal;
    }

    for (let i = 1; i < input.length; i++) {
        let crystal = input[i];
        console.log(`Processing chunk ${crystal} microns`);

        while (crystal >= target) {
            if (stage === 1) {
                if (crystal / 4 >= target) {
                    crystal /= 4;
                    actions++;
                }
                else {
                    stage++;
                    if (actions !== 0) {
                        console.log(`Cut x${actions}`);
                        crystal = wash(crystal);
                    }

                    if (crystal === target) {
                        break;
                    }
                }
            }
            else if (stage === 2) {
                if (crystal * 0.80 >= target) {
                    crystal *= 0.80;
                    actions++;
                }
                else {
                    stage++;
                    if (actions !== 0) {
                        console.log(`Lap x${actions}`);
                        crystal = wash(crystal);
                    }

                    if (crystal === target) {
                        break;
                    }
                }
            }
            else if (stage === 3) {
                if (crystal - 20 >= target) {
                    crystal -= 20;
                    actions++;
                }
                else {
                    stage++;
                    if (actions !== 0) {
                        console.log(`Grind x${actions}`);
                        crystal = wash(crystal);
                    }

                    if (crystal === target) {
                        break;
                    }
                }
            }
            else if (stage === 4) {
                if (crystal - 2 >= target || target - (crystal - 2) === 1) {
                    crystal -= 2;
                    actions++;
                }
                else {
                    if (actions !== 0) {
                        if (crystal !== target) {
                            actions++;
                        }

                        console.log(`Etch x${actions}`);
                        crystal = wash(crystal);
                    }

                    if (crystal === target) {
                        break;
                    }
                }
            }
        }

        crystal = Math.floor(crystal);

        if (crystal - 1 === target) {
            crystal -= 1;
            console.log(`X-ray x1`);
        }
        else if (crystal + 1 === target) {
            crystal += 1;
            console.log(`X-ray x1`);
        }

        stage = 1;
        console.log(`Finished crystal ${crystal} microns`);
    }
}

radioCrystals([1000, 4000, 8100]);
//radioCrystal([1375, 50000]);

//radioCrystals([100, 101.9]);
// radioCrystal(['100', '100.1', '101.9', '102']);