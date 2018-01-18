function monthlyCalendar(input) {
    let day = input[0];
    let month = input[1];
    let year = input[2];
    let daysInPrevMonth = 0;
    let daysInNextMonth = 0;
    let thisMonth = new Date(year, month, 0);
    let prevMonth = new Date(year, month - 1, 0);

    let result = '';

    result = ''.concat(result, '<table>');
    result = ''.concat(result, '\n');
    result = ''.concat(result, '<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>');
    result = ''.concat(result, '\n');
    result = ''.concat(result, '<tr>');

    for (let i = prevMonth.getDate() - prevMonth.getDay(); i <= prevMonth.getDate(); i++) {
        if (i <= prevMonth.getDate() - 6) {
            break;
        }

        result = ''.concat(result, `<td class="prev-month">${i}</td>`);
        daysInPrevMonth++;
    }

    for (let i = 1; i <= 7 - daysInPrevMonth; i++) {
        if (day === i) {
            result = ''.concat(result, `<td class="today">${day}</td>`);
        }
        else {
            result = ''.concat(result, `<td>${i}</td>`);
        }
    }

    result = ''.concat(result, '</tr>');
    for (let i = 7 - daysInPrevMonth + 1; i <= thisMonth.getDate(); i++) {
        if ((i + daysInPrevMonth - 1) % 7 === 0) {
            result = ''.concat(result, '\n');
            result = ''.concat(result, '  <tr>');
            daysInNextMonth = 0;
        }

        if (day === i) {
            result = ''.concat(result, `<td class="today">${day}</td>`);
        }
        else {
            result = ''.concat(result, `<td>${i}</td>`);
        }

        if ((i + daysInPrevMonth) % 7 === 0) {
            result = ''.concat(result, '</tr>');
        }

        daysInNextMonth++;
    }


    for (let i = 1; i <= 7 - daysInNextMonth; i++) {
        result = ''.concat(result, `<td class="next-month">${i}</td>`);
    }

    if (!result.endsWith('</tr>')) {
        result = ''.concat(result, '</tr>');
    }

    result = ''.concat(result, '\n');
    result = ''.concat(result, '</table>');

    return result;
}

//monthlyCalendar([24, 12, 2012]);
console.log(monthlyCalendar([30, 6, 1986]));