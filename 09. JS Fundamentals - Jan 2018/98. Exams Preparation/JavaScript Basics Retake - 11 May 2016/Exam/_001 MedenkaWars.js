function medenkaWars(input) {
    let whiteDmg = 0;
    let blackDmg = 0;

    let whiteSpecialAttack = 0;
    let blackSpecialAttack = 0;

    let whiteLastDmg = Number.MIN_VALUE;
    let blackLastDmg = Number.MIN_VALUE;

    for (let obj of input) {
        let data = obj.split(' ');
        let amount = Number(data[0]);
        let type = data[1];
        let dmg = amount * 60;
        if (type === 'white') {
            if (whiteLastDmg === dmg) {
                whiteSpecialAttack++;

                if (whiteSpecialAttack === 2) {
                    dmg *= 2.75;
                    whiteSpecialAttack = 0;
                }
            }
            else {
                whiteLastDmg = dmg;
                whiteSpecialAttack = 1;
            }

            whiteDmg += dmg;
        }

        else if (type === 'dark') {
            if (blackLastDmg === dmg) {
                blackSpecialAttack++;

                if (blackSpecialAttack === 5) {
                    dmg *= 4.5;
                    blackSpecialAttack = 0;
                }
            }
            else {
                blackLastDmg = dmg;
                blackSpecialAttack = 1;
            }

            blackDmg += dmg;
        }
    }

    if (whiteDmg > blackDmg) {
        console.log('Winner - Vitkor');
        console.log(`Damage - ${whiteDmg}`);
    }
    else if (whiteDmg < blackDmg) {
        console.log('Winner - Naskor');
        console.log(`Damage - ${blackDmg}`);
    }
}

medenkaWars(['5 white medenkas',
    '5 dark medenkas',
    '4 white medenkas',
]);

console.log('\n---\n');

medenkaWars(['2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
]);