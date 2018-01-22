function addAndRemoveElementsFromArray(input) {
    let result = [];
    let number = 1;
    for (let value of input) {
        if (value === 'add') {
            result.push(number++)
        }
        else if (value === 'remove') {
            result.pop();
            number++;
        }
    }

    if (result.length === 0) {
        console.log('Empty');
    }
    else {
        console.log(result.join('\n'));
    }
}

addAndRemoveElementsFromArray(['add',
    'add',
    'remove',
    'add',
    'add'
]);