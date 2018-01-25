function extractText(text) {
    let result = [];
    let startIndex = 0;
    let endIndex = 0;

    startIndex = text.indexOf('(');

    while (startIndex > -1) {
        endIndex = text.indexOf(')', startIndex);

        if (endIndex !== -1) {
            result.push(text.substring(startIndex + 1, endIndex));
            startIndex = text.indexOf('(', endIndex);
        }
        else {
            break;
        }
    }

    console.log(result.join(', '));
}

extractText('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');