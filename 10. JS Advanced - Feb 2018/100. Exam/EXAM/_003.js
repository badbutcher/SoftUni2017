class PaymentProcessor {
    constructor(obj) {
        this.obj = {
            types: ["service", "product", "other"],
            precision: 2
        };

        if (obj !== undefined && obj.hasOwnProperty('types')) {
            this.obj.types = obj.types;
        }

        if (obj !== undefined && obj.hasOwnProperty('precision')) {
            this.obj.precision = obj.precision;
        }


        this.payments = [];
    }

    registerPayment(id, name, type, value) {
        let foundId = this.payments.filter(a => a.id === id)[0];
        if (foundId !== undefined) {
            throw new Error('Error dub');
        }

        if (id === '') {
            throw new Error('Error 1');
        }

        if (name === '') {
            throw new Error('Error 2');
        }

        if (isNaN(value)) {
            throw new Error('Error 3');
        }

        if (!this.obj.types.includes(type)) {
            throw new Error('Error 4');
        }

        this.payments.push({id, name, type, value});
    }

    deletePayment(id) {
        let foundId = this.payments.filter(a => a.id === id)[0];
        if (foundId === undefined) {
            throw new Error('Error del');
        }

        this.payments.splice(this.payments.findIndex(a => a === foundId), 1)
    }

    get(id) {
        let foundId = this.payments.filter(a => a.id === id)[0];
        if (foundId === undefined) {
            throw new Error('Error get');
        }

        let result = `Details about payment ID: ${id}\n`;
        result += `- Name: ${foundId.name}\n`;
        result += `- Type: ${foundId.type}\n`;
        result += `- Value: ${foundId.value.toFixed(this.obj.precision)}`;

        return result;
    }

    setOptions(options) {
        if (this.obj !== undefined && options.hasOwnProperty('types')) {
            this.obj.types = options.types;
        }

        if (this.obj !== undefined && options.hasOwnProperty('precision')) {
            this.obj.precision = options.precision;
        }
    }

    toString() {
        let sum = 0;

        for (let val of this.payments) {
            sum += Number(val.value);
        }

        let result = 'Summary:\n';
        result += `- Payments: ${this.payments.length}\n`;
        result += `- Balance: ${sum.toFixed(this.obj.precision)}`;
        return result;
    }
}


const generalPayments = new PaymentProcessor();

console.log(generalPayments.toString());

generalPayments.registerPayment('0001', 'Microchips', 'product', 15000.03);
console.log(generalPayments.toString());

generalPayments.registerPayment('01A3', 'Biopolymer', 'product', 23000);
generalPayments.registerPayment('01', 'HR Consultation', 'service', 3000);
console.log(generalPayments.toString());