function subSum(array, start, end) {
    if (!Array.isArray(array)) {
        return NaN;
    }

    let sum = 0;
    start = Math.max(0, start);
    if (end <= start || end >= array.length) {
        end = array.length - 1;
    }

    for (let i = start; i <= end; i++) {
        sum += Number(array[i])
    }

    return sum;
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(subSum([10, 'twenty', 30, 40], 0, 2));
console.log(subSum([], 0, 0));
console.log(subSum('text', 0, 2));
