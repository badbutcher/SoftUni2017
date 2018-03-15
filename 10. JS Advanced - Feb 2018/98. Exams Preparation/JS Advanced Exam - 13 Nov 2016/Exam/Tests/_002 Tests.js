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
            expect(arr.toString().to.be.equal('test'));
        });
    });
});
