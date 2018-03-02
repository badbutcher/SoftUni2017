let expect = require('chai').expect;
const isOddOrEven = require('../_002 EvenOrOdd.js');

describe('Symmetry tests', function () {
    it('Should return undefined when input is not string', function () {
        expect(isOddOrEven(123)).to.be.equal(undefined);
    });
    it('Should return undefined when input is not string', function () {
        expect(isOddOrEven([])).to.be.equal(undefined);
    });
    it('Should return undefined when input is not string', function () {
        expect(isOddOrEven(false)).to.be.equal(undefined);
    });
    it('aaaa should return even', function () {
        expect(isOddOrEven('aaaa')).to.be.equal('even');
    });
    it('aabbaa should return even', function () {
        expect(isOddOrEven('aabbaa')).to.be.equal('even');
    });
    it('cfaaaafc should return even', function () {
        expect(isOddOrEven('cfaaaafc')).to.be.equal('even');
    });
    it('aaa should return odd', function () {
        expect(isOddOrEven('aaa')).to.be.equal('odd');
    });
    it('aba should return odd', function () {
        expect(isOddOrEven('aba')).to.be.equal('odd');
    });
    it('cfafc should return odd', function () {
        expect(isOddOrEven('cfafc')).to.be.equal('odd');
    });
    it('empty should return even', function () {
        expect(isOddOrEven('')).to.be.equal('even');
    });
});