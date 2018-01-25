function sortAnArrayBy2Criteria(input) {
    input.sort();
    input.sort((a, b) => a.length - b.length);
    console.log(input.join('\n'));
}

sortAnArrayBy2Criteria(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George',
]);