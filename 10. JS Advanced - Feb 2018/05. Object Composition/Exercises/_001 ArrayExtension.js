(function arrayExtension() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        let newArr = [];
        for (let i = n; i < this.length; i++) {
            newArr.push(this[i])
        }

        return newArr;
    };

    Array.prototype.take = function (n) {
        let newArr = [];
        for (let i = 0; i < n; i++) {
            newArr.push(this[i])
        }

        return newArr;
    };

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    };

    Array.prototype.average = function () {
        let avg = this.reduce((a, b) => a + b);
        let result = avg / this.length;
        return result;
    };
})();

let arr = [1, 2, 3, 4, 5];
console.log(arr.last());
console.log(arr.skip(2));
console.log(arr.take(2));
console.log(arr.sum());
console.log(arr.average());