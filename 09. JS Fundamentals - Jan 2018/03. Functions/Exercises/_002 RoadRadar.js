function roadRadar(input) {
    let driverSpeed = input[0];
    let area = input[1];
    let speed = getSpeed(area);
    let overTheSpeed = driverSpeed - speed;

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

    function getSpeed(area) {
        switch (area) {
            case 'motorway':
                return 130;
            case 'interstate':
                return 90;
            case 'city':
                return 50;
            case 'residential':
                return 20;
            default:
                break;
        }
    }
}


roadRadar([40, 'city']);
roadRadar([21, 'residential']);
roadRadar([120, 'interstate']);
roadRadar([200, 'motorway']);
