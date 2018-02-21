function calendar(input) {
    let day = Number(input[0]);
    let month = Number(input[1]);
    let year = Number(input[2]);
    let date = new Date(year, month - 1, 0);
    let endOfMonth = 32 - new Date(year, month - 1, 32).getDate();
    let monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    let content = $('#content');
    let table = $('<table>').append($('<caption>').text(`${monthNames[month - 1]} ${year}`));

    let body = $('<tbody>').append($('<tr>')
        .append($('<th>').text("Mon"))
        .append($('<th>').text("Tue"))
        .append($('<th>').text("Wed"))
        .append($('<th>').text("Thu"))
        .append($('<th>').text("Fri"))
        .append($('<th>').text("Sat"))
        .append($('<th>').text("Sun")));

    date.setDate(date.getDate() - date.getDay());

    for (let row = 0; row < 4; row++) {
        let tableRow = $('<tr>');
        body.append(tableRow);

        for (let col = 0; col < 7; col++) {
            date.setDate(date.getDate() + 1);

            if (date.getMonth() === month - 1) {
                if (date.getDate() === day) {
                    tableRow.append($('<td>').addClass('today').text(`${date.getDate()}`))
                }
                else {
                    tableRow.append($('<td>').text(`${date.getDate()}`))
                }
            }
            else {
                tableRow.append($('<td>'))
            }
        }

        if (date.getMonth() === month - 1 &&
            row === 3 &&
            endOfMonth > date.getDate()) {
            row--
        }
    }

    table.append(body);
    content.append(table);
}