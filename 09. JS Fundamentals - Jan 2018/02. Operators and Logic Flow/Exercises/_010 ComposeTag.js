function composeTag(input) {
    let file = input[0];
    let altName = input[1];

    console.log(`<img src="${file}" alt="${altName}">`);
}

composeTag(['smiley.gif', 'Smiley Face']);