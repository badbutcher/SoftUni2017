function capitalizeTheWords(input) {
    let words = input.split(' ');
    let result = [];
    for (let i = 0; i < words.length; i++) {
        let word = words[i].toLowerCase();
        result.push(word[0].toUpperCase() + word.substring(1));
    }

    console.log(result.join(' '));
}

capitalizeTheWords('Capitalize these words');