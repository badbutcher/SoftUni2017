function countWordsInAText(input) {
    let result = {};
    let re = new RegExp(/\W+/, 'g');
    input = input[0].replace(re, ' ').trim().split(' ');
    for (let obj of input) {
        if (!result.hasOwnProperty(obj)) {
            result[obj] = 1;
        }
        else {
            result[obj] += 1
        }
    }

    console.log(JSON.stringify(result));
}

countWordsInAText(['Far too slow, you\'re far too slow.']);
//countWordsInAText(['Far', 'too', 'slow', 'you', 're', 'far', 'too', 'slow.']);