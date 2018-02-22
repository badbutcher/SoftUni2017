function sortArray(array, sortType) {
    if (sortType.toLowerCase() === 'asc') {
        return array.sort(function (a, b) {
            return a - b;
        });
    } else if (sortType.toLowerCase() === 'desc') {
        return array.sort(function (a, b) {
            return b - a;
        });
    }
}

sortArray([14, 7, 17, 6, 8], 'asc');
sortArray([14, 7, 17, 6, 8], 'desc');