class PaymentManager {
    constructor(title) {
        this.title = title;
    }

    render(id) {
        let div = $('#' + id);
        let table = $('<table>');
        let caption = $(`<caption>${this.title} Payment Manager</caption>`);
        table.append(caption);

        let thead = $('<thead>');
        let theadTr = $('<tr>');
        let theadTrTh1 = $(`<th class="name">Name</th>`);
        let theadTrTh2 = $(`<th class="category">Category</th>`);
        let theadTrTh3 = $(`<th class="price">Price</th>`);
        let theadTrTh4 = $(`<th>Actions</th>`);
        theadTr.append(theadTrTh1).append(theadTrTh2).append(theadTrTh3).append(theadTrTh4);
        thead.append(theadTr);
        table.append(thead);

        let tbody = $('<tbody>').addClass('payments');
        table.append(tbody);

        let tfoot = $('<tfoot>').addClass('input-data');
        let tfoodTr = $('<tr>');
        let tfoodTrTd1 = $(`<td><input name="name" type="text"></td>`);
        let tfoodTrTd2 = $(`<td><input name="category" type="text"></td>`);
        let tfoodTrTd3 = $(`<td><input name="price" type="number"></td>`);
        let tfoodTrTdButton = $(`<td>`);
        tfoodTrTdButton.append($('<button>').on('click', this.add(id)).text('Add'));
        tfoodTr.append(tfoodTrTd1).append(tfoodTrTd2).append(tfoodTrTd3).append(tfoodTrTdButton);
        tfoot.append(tfoodTr);
        table.append(tfoot);
        div.append(table);
        return div;
    }

    add(id) {
        return function () {
            let name = $(`#${id} input[name*='name']`);
            let category = $(`#${id} input[name*='category']`);
            let price = $(`#${id} input[name*='price']`);
            let tbodyTr = $('<tr>');
            if (name.val() !== '' && category.val() !== '' && price.val() !== '') {
                let tbodyTrTd1 = $(`<td>${name.val()}</td>`);
                let tbodyTrTd2 = $(`<td>${category.val()}</td>`);
                let tbodyTrTd3 = $(`<td>${Number(price.val())}</td>`);
                let tbodyTrTdButton = $(`<td>`);
                tbodyTrTdButton.append($('<button>').on('click', function () {
                    this.parentNode.parentNode.remove();
                }).text('Delete'));
                tbodyTr.append(tbodyTrTd1).append(tbodyTrTd2).append(tbodyTrTd3).append(tbodyTrTdButton);

                $(`#${id} .payments`).append(tbodyTr);
                name.val('');
                category.val('');
                price.val('');
            }
        }
    }
}