let expect = require("chai").expect;
const SYMMETRY = require('../_005 CheckForSymmetry.js');

describe("Symmetry tests", function () {
    it("Should return 3 ", function () {
        expect(SYMMETRY([1, 2])).to.be.equal(false);
    });
    it("Should return 3 for [1, 2]", function () {
        expect(SYMMETRY([1, 2, 1])).to.be.equal(true);
    });
    it("Should return 3 for [1, 2]", function () {
        expect(SYMMETRY([1, 2, 3, 2])).to.be.equal(false);
    });
    it("Should return 3 for [1, 2]", function () {
        expect(SYMMETRY([1, 2, 3, 2, 4])).to.be.equal(false);
    });
    it("Should return 3 for [1, 2]", function () {
        expect(SYMMETRY([])).to.be.equal(true);
    });
    it("Shjjj", function () {
        expect(SYMMETRY([[1,2,3],[1,2,3]])).to.be.equal(true);
    });
    it("Shjjj", function () {
        expect(SYMMETRY([[],{},[]])).to.be.equal(true);
    });
});