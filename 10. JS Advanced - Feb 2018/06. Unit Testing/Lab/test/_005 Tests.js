let expect = require("chai").expect;
const isSymmetric = require('../_005 CheckForSymmetry.js');

describe("Symmetry tests", function () {
    it("Should return false", function () {
        expect(isSymmetric([1, 2])).to.be.equal(false);
    });
    it("Should return true", function () {
        expect(isSymmetric([1, 2, 1])).to.be.equal(true);
    });
    it("Should return false", function () {
        expect(isSymmetric([1, 2, 3, 2])).to.be.equal(false);
    });
    it("Should return false", function () {
        expect(isSymmetric([1, 2, 3, 2, 4])).to.be.equal(false);
    });
    it("Should return true", function () {
        expect(isSymmetric([])).to.be.equal(true);
    });
    it("Should return false", function () {
        expect(isSymmetric({})).to.be.equal(false);
    });
    it("Should return false", function () {
        expect(isSymmetric({}, {})).to.be.equal(false);
    });
    it("Should return true", function () {
        expect(isSymmetric([-1, -2, -1])).to.be.equal(true);
    });
    it("Should return true", function () {
        expect(isSymmetric([true, false, true])).to.be.equal(true);
    });
    it("Should return false", function () {
        expect(isSymmetric(1)).to.be.equal(false);
    });
    it("Should return false", function () {
        expect(isSymmetric([1, true])).to.be.equal(false);
    });
    it("Should return true", function () {
        expect(isSymmetric([[1,2,3],[1,2,3]])).to.be.equal(true);
    });
    it("Should return true", function () {
        expect(isSymmetric([[],{},[]])).to.be.equal(true);
    });
});