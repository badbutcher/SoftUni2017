function attachEvents() {
    $('#items').find('li').on("click",  function () {
        if (!$(this).attr('data-selected')) {
            $(this).attr('data-selected', 'true');
            $(this).css('background-color', '#DDD');
        }
        else {
            $(this).removeAttr('data-selected');
            $(this).css('background-color', '');
        }
    });

    $('#showTownsButton').on('click', function () {
        let towns = $('#items').find('li[data-selected=true]').map(function () {
            return this.textContent;
        }).toArray().join(', ');

        $('#selectedTowns').text("Selected towns: " + towns);
    })
}
