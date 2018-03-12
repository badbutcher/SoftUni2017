class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;

        this.online = false;
        this._element = this.create();
    }

    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;
        this.toggle();
    }

    toggle() {
        if (this.online) {
            $(this._element).removeClass('online');
        } else {
            $(this._element).addClass('online');
        }
    }

    show() {
        return function () {
            let div = $(this.parentNode.parentNode)[0];
            if (this.online) {
                $(this.parentNode).removeClass('online');
                this.online = false;
                $(div).find('.info').css('display', 'none')
            } else {
                $(this.parentNode).addClass('online');
                this.online = true;
                $(div).find('.info').css('display', 'block')
            }
        }
    }

    create() {
        let result = ($('<article>')
                .append($('<div>').addClass('title').text(`${this.firstName} ${this.lastName}`)
                    .append($('<button>').html('&#8505;').on('click', this.show()))
                ).append($('<div>').addClass('info').css('display', 'none')
                    .append($('<span>').html(`&phone; ${this.phone}`))
                    .append($('<span>').html(`&#9993; ${this.email}`)))
        );

        return result;
    }

    render(target) {
        $(`#${target}`).append(this._element);
    }
}