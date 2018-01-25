function splitAStringWithADelimiter(text, delimiter) {
    let result = text.split(delimiter);
    console.log(result.join('\n'));
}

splitAStringWithADelimiter('One-Two-Three-Four-Five',
    '-'
);