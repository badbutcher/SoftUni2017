function checkIfStringStartsWithAGivenSubstring(text, subString) {
    return text.startsWith(subString);
}

console.log(checkIfStringStartsWithAGivenSubstring('How have you been?',
    'how'
));