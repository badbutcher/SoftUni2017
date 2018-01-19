function roadRadar(input) {
    let driverSpeed = input[0];
    let area = input[1];
    let speed = 0;
    let overTheSpeed = 0;

    switch (area) {
        case 'motorway':
            speed = 130;
            break;
        case 'interstate':
            speed = 90;
            break;
        case 'city':
            speed = 50;
            break;
        case 'residential':
            speed = 20;
            break;
        default:
            break;
    }

    overTheSpeed = driverSpeed - speed;

    if (overTheSpeed <= 0) {
        console.log();
    }
    else if (overTheSpeed <= 20) {
        console.log('speeding');
    }
    else if (overTheSpeed <= 40) {
        console.log('excessive speeding');
    }
    else if (overTheSpeed <= 80) {
        console.log('reckless driving');
    }
}


roadRadar([40, 'city']);
roadRadar([21, 'residential']);
roadRadar([120, 'interstate']);
roadRadar([200, 'motorway']);
