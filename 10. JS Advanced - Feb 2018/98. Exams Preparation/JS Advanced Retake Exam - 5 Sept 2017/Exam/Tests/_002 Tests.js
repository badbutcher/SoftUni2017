let chai = require('chai');
let expect = chai.expect;
let StringBuilder = require('../_002 StringBuilder');

describe('String Builder tests', function () {
    let arr;
    beforeEach(function () {
        arr = new StringBuilder();
    });

    describe('Initial tests', function () {
        it('Has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(arr).hasOwnProperty('append')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('prepend')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('insertAt')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('remove')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('toString')).to.equal(true);
        });
    });

    describe('Append tests', function () {
        it('Append empty', function () {
            expect(() => arr.append(123)).to.throw(TypeError);
        });
        it('Append int', function () {
            expect(() => arr.append()).to.throw(TypeError);
        });
        it('Append string', function () {
            arr.append('pavel');
            expect(arr.toString()).to.be.equal('pavel');
        });
        it('Append two string', function () {
            arr.append('pavel');
            arr.append('pe6ho');
            expect(arr.toString()).to.be.equal('pavelpe6ho');
        });
    });

    describe('Prepend tests', function () {
        it('Prepend empty', function () {
            expect(() => arr.prepend(123)).to.throw(TypeError);
        });
        it('Prepend int', function () {
            expect(() => arr.prepend()).to.throw(TypeError);
        });
        it('Prepend string', function () {
            arr.prepend('pavel');
            expect(arr.toString()).to.be.equal('pavel');
        });
        it('Prepend two strings', function () {
            arr.prepend('pavel');
            arr.prepend('pe6ho');
            expect(arr.toString()).to.be.equal('pe6hopavel');
        });
    });

    describe('InsertAt tests', function () {
        it('Insert at', function () {
            arr.insertAt('a', 0);
            arr.insertAt('b', 1);
            arr.insertAt('c', 0);
            expect(arr.toString()).to.be.equal('cab');
        });
    });

    describe('Remove tests', function () {
        it('Remove at', function () {
            arr.append('abc');
            arr.remove(1, 2);
            expect(arr.toString()).to.be.equal('a');
        });
        it('Remove negative length', function () {
            arr.append('abc');
            arr.remove(3, -2);
            expect(arr.toString()).to.be.equal('abc');
        });
    });

    describe('ToString tests', function () {
        it('Return empty', function () {
            expect(arr.toString()).to.be.equal('');
        });
    });
});