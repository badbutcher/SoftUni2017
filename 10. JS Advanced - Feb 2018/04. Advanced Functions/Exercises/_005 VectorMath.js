(function vectorMath() {
    return {
        add: function add(arr1, arr2) {
            let result = [];
            result.push(arr1[0] + arr2[0]);
            result.push(arr1[1] + arr2[1]);
            return result;
        },
        multiply: function multiply(arr1, multiplier) {
            let result = [];
            result.push(arr1[0] * multiplier);
            result.push(arr1[1] * multiplier);
            return result;
        },
        length: function length(input) {
            return Math.sqrt(Math.pow(input[0], 2) + Math.pow(input[1], 2));
        },
        dot: function dot(arr1, arr2) {
            return (arr1[0] * arr2[0]) + (arr1[1] * arr2[1]);
        },
        cross: function cross(arr1, arr2) {
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


