function rotateArray(input) {
    let rotations = input[input.length - 1];
    input.pop();

    for (let i = 0; i < rotations % input.length; i++) {
        let item = input.pop();
        input.unshift(item);
    }

    console.log(input.join(' '));
}

rotateArray(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15',]);

rotateArray(['1',
    '2',
    '3',
    '4',
    '2',]);