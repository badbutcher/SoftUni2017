let chai = require('chai');
let expect = chai.expect;
let PaymentPackage = require('../_002');

describe('Payment Package tests', function () {
    let arr;
    beforeEach(function () {
        arr = new PaymentPackage('food', 10);
    });

    describe('Initial tests', function () {
        it('has functions attached to prototype', function () {
            expect(arr.name).to.be.equal('food');
            expect(arr.value).to.be.equal(10);
            expect(arr.VAT).to.be.equal(20);
            expect(arr.active).to.be.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('constructor')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('name')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('value')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('VAT')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('active')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('toString')).to.equal(true);
        });
    });

    describe('name tests', function () {
        it('Correct string', function () {
            arr.name = 'drink';
            expect(arr.name).to.be.equal('drink');
        });
        it('Throw with number', function () {
            expect(() => arr.name = 1).to.throw(Error);
        });
        it('Throw with arr', function () {
            expect(() => arr.name = []).to.throw(Error);
        });
        it('Throw with empty string', function () {
            expect(() => arr.name = '').to.throw(Error);
        });
    });

    describe('value tests', function () {
        it('Correct int', function () {
            arr.value = 15;
            expect(arr.value).to.be.equal(15);
        });
        it('Correct double', function () {
            arr.value = 15.15;
            expect(arr.value).to.be.equal(15.15);
        });
        it('Throw with string', function () {
            expect(() => arr.value = 'asd').to.throw(Error);
        });
        it('Throw with arr', function () {
            expect(() => arr.value = []).to.throw(Error);
        });
        it('Throw with negative number', function () {
            expect(() => arr.value = -100).to.throw(Error);
        });
        it('With 0', function () {
            expect(arr.value = 0).to.be.equal(0);
        });
    });

    describe('vat tests', function () {
        it('Initial VAT value is 20', function () {
            expect(arr.VAT).to.be.equal(20);
        });
        it('Correct int', function () {
            arr.VAT = 15;
            expect(arr.VAT).to.be.equal(15);
        });
        it('Correct double', function () {
            arr.VAT = 15.15;
            expect(arr.VAT).to.be.equal(15.15);
        });
        it('Throw with string', function () {
            expect(() => arr.VAT = 'asd').to.throw(Error);
            describe('vat tests', function () {
                it('Initial VAT value is 20', function () {
                    expect(arr.VAT).to.be.equal(20);
                });
                it('Correct int', function () {
                    arr.VAT = 15;
                    expect(arr.VAT).to.be.equal(15);
                });
        it('Throw with negative number', function () {
            expect(() => arr.VAT = -100).to.throw(Error);
        });
        it('With 0', function () {
            expect(arr.VAT = 0).to.be.equal(0);
        });
    });

    describe('active tests', function () {
        it('Initial active value is true', function () {
            expect(arr.active).to.be.equal(true);
        });
        it('Correct bool', function () {
            arr.active = false;
            expect(arr.active).to.be.equal(false);
        });
        it('Correct bool change', function () {
            arr.active = false;
            arr.active = true;
            expect(arr.active).to.be.equal(true);
        });
        it('Throw with string', function () {
            expect(() => arr.active = 'asd').to.throw(Error);
        });
        it('Throw with arr', function () {
            expect(() => arr.active = []).to.throw(Error);
        });
        it('Throw with number', function () {
            expect(() => arr.active = -100).to.throw(Error);
        });
    });

    describe('toString tests', function () {
        it('return correct result with active true', function () {
            arr.name = 'HR Services';
            arr.value = 1500;
            arr.VAT = 20;
            arr.active = true;
            let result = `Package: ${arr.name}\n`;
            result += `- Value (excl. VAT): ${arr.value}\n`;
            result += `- Value (VAT ${arr.VAT}%): ${arr.value * (1 + arr.VAT / 100)}`;
            expect(arr.toString()).to.be.equal(result);
        });

        it('return correct result with active false', function () {
            arr.name = 'HR Services';
            arr.value = 1500;
            arr.VAT = 20;
            arr.active = false;
            let result = `Package: ${arr.name} (inactive)\n`;
            result += `- Value (excl. VAT): ${arr.value}\n`;
            result += `- Value (VAT ${arr.VAT}%): ${arr.value * (1 + arr.VAT / 100)}`;
            expect(arr.toString()).to.be.equal(result);
        });
    });
});