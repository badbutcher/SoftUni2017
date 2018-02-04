function heroicInventory(input) {
    let result = [];
    let re = new RegExp(/ \/ /, 'g');
    for (let value of input) {
        let data = value.split(re);
        let name = data[0];
        let level = Number(data[1]);
        let items = [];
        if (data.length > 2) {
            items = data[2].split(', ');
        }

        let hero = {name: name, level: level, items: items};
        result.push(hero);
    }

    console.log(JSON.stringify(result));
}

heroicInventory(['Isacc / 25 / ',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);