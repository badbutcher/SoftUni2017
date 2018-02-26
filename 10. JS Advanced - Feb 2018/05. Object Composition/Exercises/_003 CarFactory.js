function carFactory(input) {
    let engines = {
        small: {power: 90, volume: 1800},
        normal: {power: 120, volume: 2400},
        monster: {power: 200, volume: 3500}
    };

    let engine = function () {
        let userPower = input.power;
        if (userPower <= 90) {
            return engines.small;
        } else if (userPower <= 120) {
            return engines.normal;
        } else if (userPower <= 200) {
            return engines.monster;
        }
    };

    let carriage = function () {
        let userCarriage = input.carriage;
        let userColor = input.color;
        if (userCarriage === 'hatchback') {
            return {type: 'hatchback', color: userColor}
        } else if (userCarriage === 'coupe') {
            return {type: 'coupe', color: userColor}
        }
    };

    let wheels = function () {
        let userWheels = input.wheelsize;
        if (userWheels % 2 === 0) {
            userWheels--;
            return [userWheels, userWheels, userWheels, userWheels]
        } else {
            return [userWheels, userWheels, userWheels, userWheels]
        }
    };

    let result = {
        model: input.model,
        engine: engine(),
        carriage: carriage(),
        wheels: wheels()
    };

    return result;
}

carFactory({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
);

carFactory({
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
);