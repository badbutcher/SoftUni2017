class SortedList {
    constructor() {
        this.arr = [];
        this.size = 0;
    }

    add(element) {
        this.arr.push(element);
        this.size++;
        this.sort();
        return this.arr;
    };

    remove(index) {
        if (index >= 0 && index < this.arr.length) {
            this.arr.splice(index, 1);
            this.size--;
            this.sort();
            return this.arr;
        }
    };

    get(index) {
        if (index >= 0 && index < this.arr.length) {
            return this.arr[index];
        }
    };

    sort() {
        this.arr.sort(function (a, b) {
            return a - b;
        })
    }
}

let str = new SortedList();
str.add(10);
str.add(25);
str.remove(0);
str.get(2);
console.log(str.size);