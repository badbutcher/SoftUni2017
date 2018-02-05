function minkaTheJavaScriptGoddess(input) {
    let tasks = {};
    for (let obj of input) {
        let data = obj.split(/\s+&\s+/g);
        let name = data[0];
        let type = data[1];
        let taskNumber = 'Task ' + data[2];
        let score = Number(data[3]);
        let linesOfCode = Number(data[4]);

        if (!tasks.hasOwnProperty(taskNumber)) {
            tasks[taskNumber] = {tasks: [], average: 0, lines: 0};
        }

        let nameType = {name: name, type: type};
        tasks[taskNumber].tasks.push(nameType);
        tasks[taskNumber].average += score;
        tasks[taskNumber].lines += linesOfCode;
    }

    for (let obj of Object.keys(tasks)) {
        tasks[obj].average = parseFloat((tasks[obj].average / tasks[obj].tasks.length).toFixed(2));
        tasks[obj].tasks.sort(function (a, b) {
            return a.name.localeCompare(b.name);
        });
    }

    let sort = Object.keys(tasks).sort(function (a, b) {
        if (tasks[a].average === tasks[b].average) {
            return tasks[a].lines - tasks[b].lines
        }
        else {
            return tasks[b].average - tasks[a].average;
        }
    });

    let result = {};
    for (let obj of sort) {
        result[obj] = tasks[obj];
    }

    console.log(JSON.stringify(result));
}

console.log('---------');
minkaTheJavaScriptGoddess(['Basket Battle & conditionals & 2 & 100 & 120',
    'Torrent Pirate & calculations & 1 & 100 & 20',
    'Encrypted Matrix & nested loops & 4 & 90 & 52',
    'Game of bits & bits & 5 & 100 & 18',
    'Fit box in box & conditionals & 1 & 100 & 95',
    'Disk & draw & 3 & 90 & 15',
    'Poker Straight & nested loops & 4 & 40 & 57',
    'Friend Bits & bits & 5 & 100 & 81',
    'Array Matcher & strings & 4 & 100 & 38',
    'Magic Wand & draw & 3 & 100 & 15',
    'Dream Item & loops & 2 & 88 & 80',
    'Knight Path & bits & 5 & 100 & 65',
    'Basket Battle & conditionals & 2 & 100 & 120',
    'Torrent Pirate & calculations & 1 & 100 & 20',
    'Encrypted Matrix & nested loops & 4 & 90 & 52',
    'Game of bits & bits & 5 & 100 & 18',
    'Fit box in box & conditionals & 1 & 100 & 95',
    'Disk & draw & 3 & 90 & 15',
    'Poker Straight & nested loops & 4 & 40 & 57',
    'Friend Bits & bits & 5 & 100 & 81'])
