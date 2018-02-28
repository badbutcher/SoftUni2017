let expect = require('chai').expect;
const lookupChar = require('../_003 CharLookup.js');

describe('LookupChar tests', function () {
    it('Should return undefined', function () {
        expect(lookupChar(123, 'sfsa')).to.be.equal(undefined);
    });
    it('Should return undefined', function () {
        expect(lookupChar([], 123)).to.be.equal(undefined);
    });
    it('Should return undefined', function () {
        expect(lookupChar('asd', 'sfsa')).to.be.equal(undefined);
    });
    it('Should return undefined', function () {
        expect(lookupChar(123, 123)).to.be.equal(undefined);
    });
    it('pavel 4.2 should return Incorrect index', function () {
        expect(lookupChar('pavel', 4.2)).to.be.equal(undefined);
    });
    it('pavel 1 should return p', function () {
        expect(lookupChar('pavel', 0)).to.be.equal('p');
    });
    it('pavel 3 should return p', function () {
        expect(lookupChar('pavel', 3)).to.be.equal('e');
    });
    it('pavel 4 should return l', function () {
        expect(lookupChar('pavel', 4)).to.be.equal('l');
    });
    it('pavel 40 should return Incorrect index', function () {
        expect(lookupChar('pavel', 40)).to.be.equal('Incorrect index');
    });
    it('pavel -50 should return Incorrect index', function () {
        expect(lookupChar('pavel', -40)).to.be.equal('Incorrect index');
    });
    it(' 0 should return Incorrect index', function () {
        expect(lookupChar('', 0)).to.be.equal('Incorrect index');
    });
    it('a 0 should return a', function () {
        expect(lookupChar('a', 0)).to.be.equal('a');
    });
});