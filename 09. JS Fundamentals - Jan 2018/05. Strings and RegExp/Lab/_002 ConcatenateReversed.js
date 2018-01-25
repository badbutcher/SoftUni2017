function concatenateReversed(words) {
    let result = '';
    for (let i = words.length - 1; i >= 0; i--) {
        result += reverseString(words[i]);
    }

    console.log(result);

    function reverseString(str) {
        return str.split("").reverse().join("");
    }
}

concatenateReversed(['I', 'am', 'student']);