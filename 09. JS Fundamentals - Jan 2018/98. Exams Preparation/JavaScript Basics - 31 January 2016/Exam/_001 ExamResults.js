function examResults(input) {
    let exam = new Map();
    let courseToAvg = input[input.length - 1].trim();
    let avr = 0;
    let count = 0;
    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(' ');
        if (data.length < 2) {
            break;
        }

        let student = data[0];
        let course = data[1];
        let examPoints = Number(data[2]);
        let courseBonuses = Number(data[3]);

        if (!exam.has(student)) {
            exam.set(student, new Map());
        }

        if (!exam.get(student).has(course)) {
            exam.get(student).set(course, 0);
        }

        let pointsToAdd = (examPoints / 100) * 20;
        if (pointsToAdd >= 20) {
            pointsToAdd += courseBonuses;
        }

        if (course === courseToAvg) {
            avr += examPoints;
            count++;
        }

        exam.get(student).set(course, pointsToAdd + exam.get(student).get(course));
    }

    for (let values of exam) {
        let result = `${values[0]}: Exam - `;
        for (let [key, value] of values[1]) {
            if (value < 20) {
                console.log(`${values[0]} failed at "${key}"`);
            }
            else {
                let grade = ((1 / 20) * value) + 2;
                if (grade >= 6) {
                    grade = 6;
                }
                result += `"${key}"; Points - ${Math.round(value * 100) / 100}; Grade - ${grade.toFixed(2)}`;
                console.log(result);
            }
        }
    }

    console.log(`"${courseToAvg}" average points -> ${Math.round((avr / count) * 100) / 100}`);
}

examResults(['Pesho C#-Advanced 100 3',
    'Gosho Java-Basics 157 3',
    'Tosho HTML&CSS 317 12',
    'Minka C#-Advanced 57 15',
    'Stanka C#-Advanced 157 15',
    'Kircho C#-Advanced 300 0',
    'Niki C#-Advanced 400 10',
    'C#-Advanced']);