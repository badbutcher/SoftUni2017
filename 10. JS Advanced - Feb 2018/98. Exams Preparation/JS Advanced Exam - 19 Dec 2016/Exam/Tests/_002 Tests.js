let chai = require('chai');
let expect = chai.expect;
let makeList = require('../_002 AddLeftAddRightClear');

describe("All tets", function() {
    let myList = [];
    beforeEach(function () {
        myList = makeList();
    });

    describe("Testing addLeft", function() {
        it("Adds string", function () {
            myList.addLeft('item');
            expect(myList.toString()).to.be.equal('item')
        });
        it("Adds integer", function () {
            myList.addLeft(123);
            expect(myList.toString()).to.be.equal('123')
        });
        it("Add two strings and one int", function () {
            myList.addLeft('pavel');
            myList.addLeft('e');
            myList.addLeft(42);
            expect(myList.toString()).to.be.equal('42, e, pavel')
        });
    });

    describe("Testing addRight", function() {
        it("Adds string", function () {
            myList.addRight('item');
            expect(myList.toString()).to.be.equal('item')
        });
        it("Adds integer", function () {
            myList.addRight(123);
            expect(myList.toString()).to.be.equal('123')
        });
        it("Add two strings and one int", function () {
            myList.addRight('pavel');
            myList.addRight('e');
            myList.addRight(42);
            expect(myList.toString()).to.be.equal('pavel, e, 42')
        });
    });

    describe("Testing addLeft and addRight", function() {
        it("Adds two string", function () {
            myList.addRight('>');
            myList.addLeft('<');
            expect(myList.toString()).to.be.equal('<, >')
        });
        it("Adds integer", function () {
            myList.addLeft(6);
            myList.addRight(9);
            expect(myList.toString()).to.be.equal('6, 9')
        });
        it("Add two strings and one int", function () {
            myList.addRight('right');
            myList.addLeft(65);
            myList.addRight('right');
            myList.addLeft(65);
            expect(myList.toString()).to.be.equal('65, 65, right, right')
        });
    });

    describe("Testing clear", function() {
        it("Clear empty", function () {
            myList.clear();
            expect(myList.toString()).to.be.equal('')
        });
        it("Clear with data", function () {
            myList.addRight('right');
            myList.addLeft(65);
            myList.clear();
            expect(myList.toString()).to.be.equal('')
        });
    });

    describe("Testing toString:", function() {
        it("On empty", function () {
            expect(myList.toString()).to.be.equal('')
        });
    });
});