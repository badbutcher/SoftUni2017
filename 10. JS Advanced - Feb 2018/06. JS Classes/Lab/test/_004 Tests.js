let expect = require("chai").expect;

describe("sum test", function () {
    it("Should return 3 for [1, 2]", function () {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it("Should return 0 for []", function () {
        expect(sum([])).to.be.equal(0);
    });
    it("Should return 1 for [1]", function () {
        expect(sum([1])).to.be.equal(1);
    });
    it("Should return 5.15 for [-1, 3.15, 1]", function () {
        expect(sum([-1, 3.15, 1])).to.be.equal(3.15);
    });
    it("Should return NaN for string", function () {
        expect(sum(['test'])).to.be.NaN;
    });
});

function sum(arr) {
    let sum = 0;
    for (let num of arr) {
        sum += Number(num);
    }

    return sum;
}
