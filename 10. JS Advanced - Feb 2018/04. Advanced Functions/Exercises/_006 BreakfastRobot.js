function breakfastRobot(input) {
    let typesOfMicroElements = {
        'carbohydrate': 0,
        'flavour': 0,
        'fat': 0,
        'protein'  : 0
    };

    let typeOfFoods = {
        'apple': {
            carbohydrate: 1,
            flavour: 2
        },
        'coke': {
            carbohydrate: 10,
            flavour: 20
        },
        'burger': {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        'omelet': {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        'cheverme': {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        },
    };

    for (let obj of input) {
        let data = obj.split(' ');
        let command = data[0];
        let value = data[1];
        let quantity = Number(data[2]);
        if (command === 'restock') {
            if (typesOfMicroElements.hasOwnProperty(value)) {
                typesOfMicroElements[value] += quantity;
                console.log('Success');
            }
        } else if (command === 'prepare') {
            if (typeOfFoods.hasOwnProperty(value)) {
                console.log(value);
            }
        } else {
            break;
        }
    }

    console.log(typesOfMicroElements);
}

breakfastRobot([
    'restock carbohydrate 10',
    'restock flavour 10',
    'prepare apple 1',
    'restock fat 10',
    'prepare burger 1',
    'report'
]);