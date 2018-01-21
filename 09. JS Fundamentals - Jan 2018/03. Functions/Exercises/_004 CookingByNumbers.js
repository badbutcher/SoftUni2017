function cookingByNumbers(input) {
    let number = input[0];
    for (let i = 1; i <= 5; i++) {
        switch (input[i]){
            case 'chop':
                console.log(number /= 2);
                break;
            case 'dice':
                console.log(number = Math.sqrt(number));
                break;
            case 'spice':
                console.log(number += 1);
                break;
            case 'bake':
                console.log(number *= 3);
                break;
            case 'fillet':
                console.log(number -= number * 0.2);
                break;
            default:
                break;
        }
    }
}

cookingByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);