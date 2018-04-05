function attachEvents() {
    $('#btnLoadTowns').on('click', getTowns);

    function getTowns() {
        let towns = $('#towns').val().split(', ').map(e => ({name: e}));

        printTowns(towns);
    }

    async function printTowns(towns) {
        await $.get('./_001 Template.hbs')
            .then(function (res) {
                let template = Handlebars.compile(res);

                let context = {
                    towns: towns
                };

                let html = template(context);
                $('#root').html(html);
            }).catch(errorFunc);

    }

    function errorFunc(err) {
        console.log(err);
    }
}