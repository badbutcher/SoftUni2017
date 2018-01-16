function letterOccurrencesInString(word, letter) {
    let count = 0;
    for (let wordLetter of word) {
        if (wordLetter === letter) {
            count++;
        }
    }

    console.log(count);
}

letterOccurrencesInString('hello', 'l');