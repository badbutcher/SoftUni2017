(function result() {
    let arr = {};

    String.prototype.add = function (element) {
        sort();
        return arr.push(element);
    };

    String.prototype.remove = function(index) {
        sort();
        return arr.splice(index, 1);
    };

    String.prototype.get = function(index) {
        sort();
        return arr[index];
    };

    String.prototype.size = function() {
        sort();
        return arr.length;
    };

    function sort() {
        arr = arr.sort(function (a, b) {
            return a - b;
        })
    }
})();

let str = res;
str = str.add(10);
str = str.add(10);
str = str.add(10);
console.log(str);
str = str.add(25);
console.log(str);
str = str.remove(0);
console.log(str);
str = str.get(2);
console.log(str);
str = str.size();
console.log(str);