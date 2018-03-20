let chai = require('chai');
let expect = chai.expect;
let SortedList = require('../_002 SortedList');

describe('String Builder tests', function () {
    let arr;
    beforeEach(function () {
        arr = new SortedList();
    });

    describe('Initial tests', function () {
        it('Has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(arr).hasOwnProperty('constructor')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('add')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('remove')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('vrfyRange')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('sort')).to.equal(true);
            expect(typeof  arr.size).to.not.equal('function');
        });
    });

    describe('Add tests', function () {
        it('Adds string', function () {
            arr.add('test');
            expect(arr.list.join(', ')).to.be.equal('test');
        });
        it('Adds int', function () {
            arr.add(5);
            expect(arr.list.join(', ')).to.be.equal('5');
        });
        it('Adds two strings and sort', function () {
            arr.add(3);
            arr.add(1);
            arr.add(2);
            expect(arr.list.join(', ')).to.be.equal('1, 2, 3');
        });
    });

    describe('Remove tests', function () {
        it('Remove element', function () {
            arr.add(1);
            arr.add(2);
            arr.remove(0);
            expect(arr.list.join(', ')).to.be.equal('2');
        });
        it('Remove with negative index', function () {
            arr.add('test');
            arr.add('test2');
            expect(() => arr.remove(-110)).to.throw(Error);
        });
        it('Remove with bigger index', function () {
            arr.add('test');
            arr.add('test2');
            expect(() => arr.remove(110)).to.throw(Error);
        });
        it('Remove with empty list', function () {
            expect(() => arr.remove(0)).to.throw(Error);
        });
    });

    describe('Get tests', function () {
        it('get element', function () {
            arr.add('test');
            arr.add('test2');
            expect(arr.get(0)).to.be.equal('test');
        });
        it('Get with negative index', function () {
            arr.add('test');
            arr.add('test2');
            expect(() => arr.get(-110)).to.throw(Error);
        });
        it('Get with bigger index', function () {
            arr.add('test');
            arr.add('test2');
            expect(() => arr.get(110)).to.throw(Error);
        });
        it('Get with empty list', function () {
            expect(() => arr.get(0)).to.throw(Error);
        });
    });

    describe('Size tests', function () {
        it('get size', function () {
            arr.add('test');
            arr.add('test2');
            expect(arr.size).to.be.equal(2);
        })
    });

    describe('Size tests', function () {
        it('get size', function () {
            arr.add(3);
            arr.add(1);
            expect(arr.size).to.be.equal(2);
        })
    });
});