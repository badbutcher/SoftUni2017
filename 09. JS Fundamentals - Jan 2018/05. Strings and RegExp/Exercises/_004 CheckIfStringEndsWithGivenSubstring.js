function checkIfStringEndsWithGivenSubstring(text, subString) {
    return text.endsWith(subString);
}

console.log(checkIfStringEndsWithGivenSubstring('This sentence ends with fun?',
    'fun?'
));