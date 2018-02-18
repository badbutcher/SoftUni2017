function initializeTable() {
    let table = $('#countriesTable');

    seed('Bulgaria', 'Sofia');
    seed('Germany', 'Berlin');
    seed('Russia', 'Moscow');

    $('#createLink').click(add);

    function add() {
        let contrite = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();
        let tr = $('<tr>');
        let tdCou = $('<td>');
        let tdCap = $('<td>');
        let tdCommands = $('<td>');
        tdCou.html(contrite);
        tdCap.html(capital);
        tdCommands.html($("<a href='#'>[Up]</a>").click(up))
            .append(" ")
            .append($("<a href='#'>[Down]</a>").click(down))
            .append(" ")
            .append($("<a href='#'>[Delete]</a>").click(remove));
        tr.append(tdCou);
        tr.append(tdCap);
        tr.append(tdCommands);
        table.append(tr);
        removeButtons();
    }

    function up() {
        let selected = $(this).parent().parent();
        selected.insertBefore(selected.prev());
        removeButtons();
    }

    function down() {
        let selected = $(this).parent().parent();
        selected.insertAfter(selected.next());
        removeButtons();
    }

    function remove() {
        $(this).parent().parent().remove();
        removeButtons();
    }

    function removeButtons() {
        $('#countriesTable').find('a').css('display', 'inline');

        let tableRows = $('#countriesTable').find('tr');
        $(tableRows[2]).find("a:contains('Up')").css('display', 'none');

        $(tableRows[tableRows.length - 1]).find("a:contains('Down')").css('display', 'none');

    }

    function seed(cou, cap) {
        let tr = $('<tr>');
        let tdCou = $('<td>');
        let tdCap = $('<td>');
        let tdCommands = $('<td>');
        tdCou.html(cou);
        tdCap.html(cap);
        tdCommands.html($("<a href='#'>[Up]</a>").click(up))
            .append(" ")
            .append($("<a href='#'>[Down]</a>").click(down))
            .append(" ")
            .append($("<a href='#'>[Delete]</a>").click(remove));
        tr.append(tdCou);
        tr.append(tdCap);
        tr.append(tdCommands);
        table.append(tr);
        removeButtons();
    }
}
