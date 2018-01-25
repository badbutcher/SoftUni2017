function findVariableNamesInSentences(input) {
    let re = new RegExp(/\b_[A-Za-z0-9]+\b/, 'g');
    let result = [];
    let match;

    while (match = re.exec(input)) {
        result.push(match[0].substring(1));
    }

    console.log(result.join(','));
}

findVariableNamesInSentences('__invalidVariable _evenMoreInvalidVariable_ _validVariable');