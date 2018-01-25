function findOccurrencesOfWordInSentence(text, word) {
    let re = new RegExp('\\b' + `${word.toLowerCase()}` + '\\b', 'g');
    let count = 0;
    let match;

    while (match = re.exec(text.toLowerCase())) {
        count++;
    }

    console.log(count);
}

findOccurrencesOfWordInSentence('The waterfall was so high, that the child couldn’t see its peak.',
    'the'
);