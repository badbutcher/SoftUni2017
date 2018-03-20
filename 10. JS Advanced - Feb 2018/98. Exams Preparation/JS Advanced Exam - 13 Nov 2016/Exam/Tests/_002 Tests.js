let chai = require('chai');
let expect = chai.expect;
let createList = require('../_002 AddSwapShiftLeftRightInList');

describe('All tests', function() {
    let arr = [];

    beforeEach(function () {
        arr = createList();
    });

    describe('Initial tests', function () {
        it('Has all functions', function() {
            expect(Object.getPrototypeOf(arr).hasOwnProperty('add'));
            expect(Object.getPrototypeOf(arr).hasOwnProperty('shiftLeft'));
            expect(Object.getPrototypeOf(arr).hasOwnProperty('shiftRight'));
            expect(Object.getPrototypeOf(arr).hasOwnProperty('swap'));
            expect(Object.getPrototypeOf(arr).hasOwnProperty('toString'));
        });
    });

    describe('Add tests', function () {
        it('Add string', function() {
            arr.add('test');
            expect(arr.toString()).to.be.equal('test');
        });
        it('Add int', function() {
            arr.add(1);
            expect(arr.toString()).to.be.equal('1');
        });
        it('Add arr', function() {
            arr.add([1, 2, 3]);
            arr.add([1, 2, 3]);
            expect(arr.toString()).to.be.equal('1,2,3, 1,2,3');
        });
    });

    describe('ShiftLeft tests', function () {
        it('Shift single value', function() {
            arr.add('test');
            arr.shiftLeft();
            expect(arr.toString()).to.be.equal('test');
        });
        it('Shift', function() {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.shiftLeft();
            expect(arr.toString()).to.be.equal('2, 3, 1');
        });
    });
    describe('ShiftRight tests', function () {
        it('Shift single value', function() {
            arr.add('test');
            arr.shiftRight();
            expect(arr.toString()).to.be.equal('test');
        });
        it('Shift', function() {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.shiftRight();
            expect(arr.toString()).to.be.equal('3, 1, 2');
        });
    });
    describe('Swap tests', function () {
        it('Swap invalid index1', function() {
            arr.add(1);
            expect(arr.swap(0, 100)).to.be.equal(false);
        });
        it('Swap invalid index2', function() {
            arr.add(1);
            expect(arr.swap(100, 0)).to.be.equal(false);
        });
        it('Swap invalid index3', function() {
            arr.add(1);
            expect(arr.swap(0, -1000)).to.be.equal(false);
        });
        it('Swap invalid index4', function() {
            arr.add(1);
            expect(arr.swap(-1000, 0)).to.be.equal(false);
        });
        it('Swap invalid index5', function() {
            arr.add(1);
            expect(arr.swap('asd', 0)).to.be.equal(false);
        });
        it('Swap invalid index6', function() {
            arr.add(1);
            expect(arr.swap(0, 'asd')).to.be.equal(false);
        });
        it('Swap invalid index7', function() {
            arr.add(1);
            expect(arr.swap(0, 0)).to.be.equal(false);
        });
        it('Swap success', function() {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.swap(0, 2);
            expect(arr.toString()).to.be.equal('3, 2, 1');
        });
        it('Swap success2', function() {
            arr.add('1');
            arr.add('2');
            arr.add('3');
            arr.swap(2, 0);
            expect(arr.toString()).to.be.equal('3, 2, 1');
        });
        it('Swap success3', function() {
            arr.add('1');
            arr.add('2');
            arr.add('3');
            arr.swap(1, 2);
            expect(arr.toString()).to.be.equal('1, 3, 2');
        });
        it('Swap success4', function() {
            arr.add('1');
            arr.add('2');
            arr.add('3');
            arr.swap(1, 1);
            expect(arr.toString()).to.be.equal('1, 2, 3');
        });
    });
    describe('ToString tests', function () {
        it('Print empty', function() {
            expect(arr.toString()).to.be.equal('');
        });
    });
});