$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let source = await $.get('./_002 Template.hbs');
        let template = Handlebars.compile(source);

        let context = {
            cats: window.cats
        };

        let html = template(context);
        $('#allCats').append(html);

        $('button').on('click', (event) => {
            let target = $(event.target);
            let next = target.next();
            if (next.css('display') === 'none') {
                //next.show();
                target.text('Hide status code');
            }
            else {
                //next.hide();
                target.text('Show status code');
            }

            next.toggle()
        });
    }
});
