function palindrome(input) {
    let isPalindrom = true;
    for (let i = 0; i < input.length; i++) {
        if (input[0] !== input[input.length - 1]) {
            isPalindrom = false;
            break;
        }
    }

    console.log(isPalindrom);
}

palindrome('unitinu');