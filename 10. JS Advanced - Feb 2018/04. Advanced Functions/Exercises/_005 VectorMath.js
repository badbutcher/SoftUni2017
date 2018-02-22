(function vectorMath() {
    return {
        add: function add(input) {
            let arr1 = input[0];
            let arr2 = input[1];
            let result = [];
            result.push(arr1[0] + arr2[0]);
            result.push(arr1[1] + arr2[1]);
            return result;
        },
        multiply: function multiply(input) {
            let arr1 = input[0];
            let multiplier = input[1];
            let result = [];
            result.push(arr1[0] * multiplier);
            result.push(arr1[1] * multiplier);
            return result;
        },
        length: function length(input) {
            let num1 = input[0];
            let num2 = input[1];
            return Math.sqrt(Math.pow(num1, 2) + Math.pow(num2, 2));
        },
        dot: function dot(input) {
            let arr1 = input[0];
            let arr2 = input[1];
            let result = (arr1[0] + arr2[0]) + (arr1[1] + arr2[1]);
            return result;
        },
        cross: function cross(input) {
            let arr1 = input[0];
            let arr2 = input[1];
            let result = (arr1[0] * arr2[1]) - (arr1[1] * arr2[0]);
            return result;
        }
    };
})();

vectorMath.add([[1, 1], [1, 0]]);
vectorMath.multiply([[3.5, -2], 2]);
vectorMath.length([3, -4]);
vectorMath.dot([[1, 0], [0, -1]]);
vectorMath.cross([[3, 7], [1, 0]]);


