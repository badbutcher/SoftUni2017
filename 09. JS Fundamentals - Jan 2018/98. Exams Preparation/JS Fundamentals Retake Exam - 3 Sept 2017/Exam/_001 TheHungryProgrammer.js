function theHungryProgrammer(meals, commands) {
    let mealsEaten = 0;

    for (let value of commands) {
        let command = value.split(' ');
        if (command[0] === 'End') {
            break;
        }
        else if (command[0] === 'Serve' && meals.length >= 1) {
            let item = meals.pop();
            console.log(`${item} served!`);
        }
        else if (command[0] === 'Eat' && meals.length >= 1) {
            let item = meals.shift();
            mealsEaten++;
            console.log(`${item} eaten`);
        }
        else if (command[0] === 'Add' && command.length === 2) {
            let food = command[1];
            meals.unshift(food);
        }
        else if (command[0] === 'Shift' && meals.length >= 1 && command.length === 3) {
            let startIndex = command[1];
            let endIndex = command[2];
            if (meals[startIndex] !== undefined && meals[endIndex] !== undefined) {
                let b = meals[startIndex];
                meals[startIndex] = meals[endIndex];
                meals[endIndex] = b;
            }
        }
        else if (command[0] === 'Consume' && meals.length >= 1 && command.length === 3) {
            let startIndex = Number(command[1]);
            let endIndex = Number(command[2]);
            if (meals[startIndex] !== undefined && meals[endIndex] !== undefined) {
                let removed = meals.splice(startIndex, endIndex - startIndex + 1);
                mealsEaten += removed.length;
                console.log('Burp!');
            }
        }
    }

    if (meals.length >= 1) {
        console.log(`Meals left: ${meals.join(', ')}`);
    }
    else {
        console.log('The food is gone');
    }

    console.log(`Meals eaten: ${mealsEaten}`);
}

// function getSnatchMeals(meals, commandArgs) {
//     let mealsEaten = 0;
//     let actions = {
//         Serve: () => {
//             if (meals.length > 0)
//                 console.log(`${meals.pop()} served!`)
//         },
//         Eat: () => {
//             if (meals.length > 0) {
//                 console.log(`${meals.shift()} eaten`);
//                 mealsEaten++;
//             }
//         },
//         End: () => {
//             if (meals.length > 0) {
//                 console.log(`Meals left: ${meals.join(', ')}`);
//             }
//             else {
//                 console.log("The food is gone");
//             }
//             console.log(`Meals eaten: ${mealsEaten}`);
//         },
//         Add: ([meal]) => {
//             if (meal && meal !== '')
//                 meals.unshift(meal)
//         },
//         Shift: ([startIdx, endIdx]) => {
//             let hasValidIndexes = endIdx > 0 && startIdx >= 0
//                 && endIdx < meals.length && startIdx < endIdx;
//
//             if (hasValidIndexes) {
//                 let temp = meals[startIdx];
//                 meals[startIdx] = meals[endIdx];
//                 meals[endIdx] = temp;
//             }
//         },
//         Consume: ([startIdx, endIdx]) => {
//             let hasValidIndexes = startIdx >= 0 && endIdx > 0
//                 && startIdx < endIdx && endIdx < meals.length;
//
//             if (hasValidIndexes) {
//                 let mealsToEat = endIdx - startIdx + 1;
//                 meals.splice(startIdx, mealsToEat);
//                 mealsEaten += mealsToEat;
//                 console.log('Burp!');
//             }
//         }
//     };
//
//     for (let command of commandArgs) {
//         let args = command.split(' ');
//         let action = args.shift();
//
//         let currentAction = actions[action];
//         if (currentAction) {
//             currentAction(args);
//             if (action === "End") {
//                 break
//             }
//         }
//     }
// }

getSnatchMeals(['bacon', 'veggies', 'chicken', 'turkey', 'eggs'],
    ['Shift 2 9',
        'Eat',
        'Serve',
        'End',
        'Serve']
);