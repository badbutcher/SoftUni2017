let expect = require("chai").expect;
const createCalculator = require('../_007 AddSubtract.js');

describe("Calculator tests", function () {
    let calculator;

    beforeEach(function () {
        calculator = createCalculator();
    });

    it("Should return 5", function () {
        calculator.add(5);
        expect(calculator.get()).to.be.equal(5);
    });
    it("Should return 10", function () {
        calculator.add(5);
        calculator.add(5);
        expect(calculator.get()).to.be.equal(10);
    });
    it("Should return 2", function () {
        calculator.add(5);
        calculator.subtract(3);
        expect(calculator.get()).to.be.equal(2);
    });
    it("Should return -3", function () {
        calculator.subtract(3);
        expect(calculator.get()).to.be.equal(-3);
    });
    it("Should return -6", function () {
        calculator.subtract(3);
        calculator.subtract(3);
        expect(calculator.get()).to.be.equal(-6);
    });
    it("Should return 0", function () {
        calculator.subtract(3);
        calculator.add(3);
        expect(calculator.get()).to.be.equal(0);
    });
    it("Should return 3 when subtracting negative number", function () {
        calculator.subtract(-3);
        expect(calculator.get()).to.be.equal(3);
    });
    it("Should return 0 if empty", function () {
        expect(calculator.get()).to.be.equal(0);
    });
    it("Should return 0", function () {
        calculator.add(10);
        calculator.subtract(2);
        calculator.add(3);
        calculator.subtract(8);
        expect(calculator.get()).to.be.equal(3);
    });
    it("Should return NaN", function () {
        calculator.add('one');
        expect(calculator.get()).to.be.NaN;
    });
    it("Should return 0 if array is given", function () {
        calculator.add([]);
        expect(calculator.get()).to.be.equal(0);
    });
    it("Should return NaN", function () {
        calculator.add([]);
        expect(calculator.get()).to.be.equal(0);
    });
});