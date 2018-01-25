function matchAllWords(words) {
    let result = '';
    let re = new RegExp(/\w+/, 'g');
    result = words.match(re);
    console.log(result.join('|'));
}

matchAllWords('A Regular Expression needs to have the global flag in order to match all occurrences in the text');