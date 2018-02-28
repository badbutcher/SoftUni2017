function result() {
    let data = (function () {
        let arr = [];
        let size = 0;
        let add = function (element) {
            arr.sort(sort);
            arr.push(element);
            size++;
            return arr;
        };

        let remove = function (index) {
            if (index >= 0 && index < arr.length) {
                arr.sort(sort);
                arr.splice(index, 1);
                size--;
                return arr;
            }
        };

        let get = function (index) {
            if (index >= 0 && index < arr.length) {
                return arr[index];
            }
        };

        function sort() {
            arr.sort(function (a, b) {
                return a - b;
            })
        }

        return {add, remove, get, size}
    })();

    return data;
}

let str = result();
str.add(10);
str.add(25);
str.remove(0);
str.get(2);
console.log(str.size);