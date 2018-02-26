function breakfastRobot() {
    let typesOfMicroElements = {
        'protein': 0,
        'carbohydrate': 0,
        'fat': 0,
        'flavour': 0
    };

    let typeOfFoods = {
        'apple': {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2
        },
        'coke': {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20
        },
        'burger': {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        'omelet': {
            protein: 5,
            carbohydrate: 0,
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

    let commands = {
        restock: (product, quantity) => {
            typesOfMicroElements[product] += Number(quantity);
            return 'Success'
        },
        prepare: (meal, quantity) => {
            try {
                validateQuantity();
                masterChefInTheHouse();
                return 'Success';
            }
            catch (e) {
                return e.message;
            }

            function masterChefInTheHouse() {
                typesOfMicroElements.protein -= typeOfFoods[meal].protein * quantity;
                typesOfMicroElements.carbohydrate -= typeOfFoods[meal].carbohydrate * quantity;
                typesOfMicroElements.fat -= typeOfFoods[meal].fat * quantity;
                typesOfMicroElements.flavour -= typeOfFoods[meal].flavour * quantity;
            }

            function validateQuantity() {
                if (typeOfFoods[meal].protein * quantity > typesOfMicroElements.protein) {
                    throw new Error(`Error: not enough protein in stock`);
                } else if (typeOfFoods[meal].carbohydrate * quantity > typesOfMicroElements.carbohydrate) {
                    throw new Error(`Error: not enough carbohydrate in stock`);
                } else if (typeOfFoods[meal].fat * quantity > typesOfMicroElements.fat) {
                    throw new Error(`Error: not enough stock in stock`);
                } else if (typeOfFoods[meal].flavour * quantity > typesOfMicroElements.flavour) {
                    throw new Error(`Error: not enough flavour in stock`);
                }
            }
        },
        report: () => {
            return `protein=${typesOfMicroElements.protein} carbohydrate=${typesOfMicroElements.carbohydrate} fat=${typesOfMicroElements.fat} flavour=${typesOfMicroElements.flavour}`;
        }
    };

    return function prepare(input) {
        input = input.split(' ');

        return commands[input.shift()](...input);
        //...input e za splitvane na areq.
    }
}

let manager = breakfastRobot();
// manager("restock flavour 50");
// manager("prepare coke 4");
// manager('report');

manager('restock carbohydrate 10');
manager('restock flavour 10');
manager('prepare apple 1');
manager('restock fat 10');
manager('prepare burger 1');
manager('report');



// for (let obj of input) {
//     let data = obj.split(' ');
//     let command = data[0];
//     let value = data[1];
//     let quantity = Number(data[2]);
//     if (command === 'restock') {
//         if (typesOfMicroElements.hasOwnProperty(value)) {
//             typesOfMicroElements[value] += quantity;
//             console.log('Success');
//         }
//     } else if (command === 'prepare') {
//         if (typeOfFoods.hasOwnProperty(value)) {
//             let food = typeOfFoods[value];
//             console.log(food);
//             for (let i = 0; i < quantity; i++) {
//                 for (let item of Object.entries(food)) {
//                     console.log(item);
//                     typesOfMicroElements[item[0]] -= item[1]
//                 }
//             }
//         }
//     } else {
//         break;
//     }
// }
//
// console.log(typesOfMicroElements);