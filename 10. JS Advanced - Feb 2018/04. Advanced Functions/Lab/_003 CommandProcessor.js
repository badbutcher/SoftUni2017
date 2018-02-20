function commandProcessor(input) {
    let command = (function () {
        let output = '';
        return {
            append: function (appender) {
                output += appender;
            },
            removeStart: function (index) {
                output = output.slice(index);
            },
            removeEnd: function (index) {
                output = output.slice(0, output.length - index);
            },
            print: function () {
                console.log(output);
            }
        }
    })();

    for (let obj of input) {
        let data = obj.split(' ');
        command[data[0]](data[1]);
    }
}

commandProcessor(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']
);