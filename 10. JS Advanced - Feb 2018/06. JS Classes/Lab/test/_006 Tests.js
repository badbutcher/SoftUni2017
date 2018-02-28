let expect = require("chai").expect;
const rgbToHexColor = require('../_006 RGBToHex.js');

describe("RGB tests", function () {
    it("Should return #323232", function () {
        expect(rgbToHexColor(50, 50, 50)).to.be.equal('#323232');
    });
    it("Should return #963232", function () {
        expect(rgbToHexColor(150, 50, 50)).to.be.equal('#963232');
    });
    it("Should return #323232", function () {
        expect(rgbToHexColor(50, 150, 50)).to.be.equal('#329632');
    });
    it("Should return #323296", function () {
        expect(rgbToHexColor(50, 50, 150)).to.be.equal('#323296');
    });
    it("Should return #ffffff", function () {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    });
    it("Should return #ffffff", function () {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });
    it("Should return undefined when red = 300", function () {
        expect(rgbToHexColor(300, 255, 255)).to.be.equal(undefined);
    });
    it("Should return undefined when green = 300", function () {
        expect(rgbToHexColor(255, 300, 255)).to.be.equal(undefined);
    });
    it("Should return undefined when blue = 300", function () {
        expect(rgbToHexColor(255, 255, 300)).to.be.equal(undefined);
    });
    it("Should return undefined when red = -100", function () {
        expect(rgbToHexColor(-100, 255, 255)).to.be.equal(undefined);
    });
    it("Should return undefined when green = -100", function () {
        expect(rgbToHexColor(255, -100, 255)).to.be.equal(undefined);
    });
    it("Should return undefined when blue = -100", function () {
        expect(rgbToHexColor(255, 255, -100)).to.be.equal(undefined);
    });
    it("Should return undefined when all are = -100", function () {
        expect(rgbToHexColor(-100, -100, -100)).to.be.equal(undefined);
    });
    it("Should return undefined when empty", function () {
        expect(rgbToHexColor()).to.be.equal(undefined);
    });
    it("Should return undefined when not int", function () {
        expect(rgbToHexColor('red', 'green', 'blue')).to.be.equal(undefined);
    });
});