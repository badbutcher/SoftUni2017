function examResults(input) {
    let courseToAvg = input[input.length - 1].trim();
    let avr = 0;
    let count = 0;
    for (let i = 0; i < input.length-1; i++) {
        let data = input[i].split(/\s+/).filter(function(e){return e});
        if (data.length < 2) {
            break;
        }

        let studentName = data[0];
        let course = data[1];
        let examPoints = Number(data[2]);
        let courseBonuses = Number(data[3]);

        if (course === courseToAvg) {
            avr += examPoints;
            count++;
        }

        let points = (examPoints / 100) * 20;
        if (points < 20) {
            console.log(`${studentName} failed at "${course}"`);
            continue;
        }
        else {
            points += courseBonuses;
        }

        let grade = ((1 / 20) * points) + 2;
        if (grade >= 6) {
            grade = 6;
        }

        console.log(`${studentName}: Exam - "${course}"; Points - ${Math.round(points * 100) / 100}; Grade - ${grade.toFixed(2)}`);

    }

    console.log(`"${courseToAvg}" average points -> ${Math.round((avr / count) * 100) / 100}`);
}

// examResults(['Pesho C#-Advanced 100 3',
// 'Gosho Java-Basics 157 3',
// 'Tosho HTML&CSS 317 12',
// 'Minka C#-Advanced 57 15',
// 'Stanka C#-Advanced 157 15',
// 'Kircho C#-Advanced 300 0',
// 'Niki C#-Advanced 400 10',
// 'C#-Advanced']);

examResults(['   EDUU    JS-Basics                317          15',
    'RoYaL        HTML5        121         10',
    'ApovBerger      OOP   0    10',
    'Stamat OOP   190 10',
    'MINKA OOP   230 10',
    'OOP']);