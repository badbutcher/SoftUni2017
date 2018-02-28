let expect = require('chai').expect;
const isSymmetric = require('../_006 ArmageDOM.js');

describe('Symmetry tests', function () {
    it('Should return falss', function () {
        expect(isSymmetric([1, 2])).to.be.equal(false);
    });
});