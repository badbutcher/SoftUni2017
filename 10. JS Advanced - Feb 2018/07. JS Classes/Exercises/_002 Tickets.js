function tickets(input, sortType) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let allTickets = [];

    for (let i = 0; i < input.length; i++) {
        let data = input[i].split('|');
        let name = data[0];
        let price = Number(data[1]);
        let status = data[2];
        let ticket = new Ticket(name, price, status);
        allTickets.push(ticket);
    }

    allTickets.sort(function (a, b) {
        return a[sortType] > b[sortType];
    });

    return allTickets;
}

let asd = tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
);

console.log(asd);