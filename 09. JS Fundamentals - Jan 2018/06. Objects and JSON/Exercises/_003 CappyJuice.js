function cappyJuice(input) {
    let juices = new Map();
    let bottles = new Map();

    for (let value of input) {
        let data = value.split(' => ');
        let juice = data[0];
        let quantity = Number(data[1]);

        if (!juices.has(juice)) {
            juices.set(juice, 0)
        }

        let quantityToAdd = Number(juices.get(juice) + quantity);
        juices.set(juice, quantityToAdd);

        if (juices.get(juice) >= 1000) {
            bottles.set(juice, Math.floor(juices.get(juice) / 1000))
        }
    }

    for (let [key, value] of bottles) {
        console.log(`${key} => ${value}`);
    }
}

cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);