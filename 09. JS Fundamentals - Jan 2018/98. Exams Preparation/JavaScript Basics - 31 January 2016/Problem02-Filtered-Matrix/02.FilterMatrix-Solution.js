function solve(arr) {
    var targetLength = parseInt(arr.pop());
    var sequence = arr.join(' ').split(' ');

    var currentCount = 1;
    for (var i = 0; i < sequence.length; i++) {
        if (sequence[i] === sequence[i + 1]) {
            currentCount++;
            if (currentCount == targetLength) {
                for (var k = i + 1; k > i + 1 - targetLength; k--) {
                    sequence[k] = false;
                }
                currentCount = 1;
            }
        } else {
            currentCount = 1;
        }
    }

    var resultArr = [];
    var index = -1;
    for (i = 0; i < arr.length; i++) {
        var currentRow = arr[i].split(' ');
        var outputRow = [];
        for (var j = 0; j < currentRow.length; j++) {
            if (sequence[++index] !== false) {
                outputRow.push(sequence[index]);
            }
        }
        resultArr.push(outputRow);
    }

    while(resultArr.length > 0) {
        var row = resultArr.shift();
        if (row.length > 0) {
            console.log(row.join(' '));
        } else {
            console.log('(empty)');
        }
    }
}
solve(['3 3 3 2 5 9 9 9 9 1 2',
    '1 1 1 1 1 2 5 8 1 1 7',
    '7 7 1 2 3 5 7 4 4 1 2',
    '2']
);