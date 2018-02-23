let functionalSum = (function () {
    let sum = 0;

    return function add(num) {
        sum += num;
        add.toString = () => sum;
        return add;
    }
})();

// function add(num) {
//     let sum = num;
//
//     function calc(num2) {
//         sum += num2;
//         return calc;
//     }
//
//     calc.toString = function() { return sum };
//     return calc;
// }

console.log(Number(functionalSum(1)(6)(-3)));