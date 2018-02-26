function cars(input) {
    let result = (function () {
        let objects = {};

        function create(arr) {
            if (arr.length > 2) {
                objects[arr[0]] = Object.create(objects[arr[2]]);
            } else {
                objects[arr[0]] = {}
            }
        }

        function set(arr) {
            let name = arr[0];
            let key = arr[1];
            let value = arr[2];
            objects[name][key] = value;
        }

        function print(arr) {
            let printArr = [];
            let obj = objects[arr[0]];
            for (let key in obj) {
                printArr.push(`${key}:${obj[key]}`)
            }

            console.log(printArr.join(', '));
        }

        return {create, set, print}
    })();

    for (let obj of input) {
        let data = obj.split(' ');
        let command = data.shift();
        result[command](data);
    }
}

cars(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);