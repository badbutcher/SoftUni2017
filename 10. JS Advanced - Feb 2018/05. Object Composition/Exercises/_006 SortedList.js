(function sortedList() {
    Array.prototype.add = function (element) {
        sort();
        this.push(element);
        return this;
    };

    Array.prototype.remove = function (index) {
        sort();
        this.splice(index, 1);
        return this;
    };

    Array.prototype.get = function (index) {
        sort();
        console.log(this[index]);
        return this;
    };

    Array.prototype.size = function () {
        sort();
        console.log(this.length);
        return this;
    };

    function sort() {
        console.log(this);
        this.sort()
    }
})();

let numbers = [5, 4, 3, 2, 1];
numbers = numbers.add(6);
console.log(numbers);
numbers = numbers.remove(5);
console.log(numbers);
numbers = numbers.get(3);
console.log(numbers);
numbers = numbers.size();
console.log(numbers);