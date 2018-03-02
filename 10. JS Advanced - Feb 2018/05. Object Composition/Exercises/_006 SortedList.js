function result() {
    let data = (function () {
        let arr = [];
        let size = 0;
        let add = function (element) {
            arr.push(element);
            this.size++;
            sort();
            return arr;
        };

        let remove = function (index) {
            if (index >= 0 && index < arr.length) {
                arr.splice(index, 1);
                this.size--;
                sort();
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