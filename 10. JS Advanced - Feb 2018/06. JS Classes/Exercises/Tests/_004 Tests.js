let expect = require('chai').expect;
const mathEnforcer = require('../_004 MathEnforcer.js');

describe('Math enforcer tests', function () {
    let match;

    beforeEach(function () {
        match = mathEnforcer;
    });
    describe('AddFive', function () {
        it('Should return undefined', function () {
            expect(match.addFive('asd')).to.be.equal(undefined);
        });
        it('Should return undefined', function () {
            expect(match.addFive([])).to.be.equal(undefined);
        });
        it('Add 5 should return 10', function () {
            expect(match.addFive(5)).to.be.equal(10);
        });
        it('Add 5.5 should return 10.5', function () {
            expect(match.addFive(5.5)).to.be.equal(10.5);
        });
        it('Add 10 should return 10', function () {
            expect(match.addFive(10)).to.be.equal(15);
        });
        it('Add -5 should return 0', function () {
            expect(match.addFive(-5)).to.be.equal(0);
        });
    });
    describe('Subtract Ten', function () {
        it('Should return undefined', function () {
            expect(match.subtractTen('asd')).to.be.equal(undefined);
        });
        it('Should return undefined', function () {
            expect(match.subtractTen([])).to.be.equal(undefined);
        });
        it('SubtractTen 15 should return 5', function () {
            expect(match.subtractTen(15)).to.be.equal(5);
        });
        it('SubtractTen 15.5 should return 5.5', function () {
            expect(match.subtractTen(15.5)).to.be.equal(5.5);
        });
        it('SubtractTen 30 should return 20', function () {
            expect(match.subtractTen(30)).to.be.equal(20);
        });
        it('SubtractTen -10 should return -20', function () {
            expect(match.subtractTen(-10)).to.be.equal(-20);
        });
    });
    describe('Sum', function () {
        it('Should return undefined', function () {
            expect(match.sum('asd', 5)).to.be.equal(undefined);
        });
        it('Should return undefined', function () {
            expect(match.sum(5, 'asd')).to.be.equal(undefined);
        });
        it('Should return undefined', function () {
            expect(match.sum('asd', 'asd')).to.be.equal(undefined);
        });
        it('Sum 5,5 should return 10', function () {
            expect(match.sum(5, 5)).to.be.equal(10);
        });
        it('Sum 2.5,2.5 should return 5', function () {
            expect(match.sum(2.5, 2.5)).to.be.equal(5);
        });
        it('Sum 15,15 should return 30', function () {
            expect(match.sum(15, 15)).to.be.equal(30);
        });
        it('Sum 10,-10 should return 0', function () {
            expect(match.sum(10, -10)).to.be.equal(0);
        });
        it('Sum 1.9,-0.1 should return 2', function () {
            expect(match.sum(1.9, 0.1)).to.be.equal(2);
        });
    });
});