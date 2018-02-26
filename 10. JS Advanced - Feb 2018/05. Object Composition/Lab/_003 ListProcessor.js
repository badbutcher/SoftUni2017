function listProcessor(input) {
    let result = (function () {
        let arr = [];

        function add(value) {
            return arr.push(value);
        }

        function remove(value) {
            return arr = arr.filter(a => a !== value);
        }

        function print() {
            return console.log(arr.join(','));
        }

        return {add, remove, print};
    })();

    for (let obj of input) {
        let data = obj.split(' ');
        let command = data[0];
        let value = data[1];
        result[command](value);
    }
}

listProcessor(['add pesho', 'add gosho', 'add pesho', 'remove pesho', 'print']);