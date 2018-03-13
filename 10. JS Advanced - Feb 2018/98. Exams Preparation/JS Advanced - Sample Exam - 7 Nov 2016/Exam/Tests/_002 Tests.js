let chai = require('chai');
let expect = chai.expect;
let listCreator = function () {
    let data = [];
    return {
        add: function (item) {
            data.push(item);
        },
        delete: function (index) {
            if (Number.isInteger(index) && index >= 0 && index < data.length) {
                return data.splice(index, 1)[0];
            } else {
                return undefined;
            }
        },
        toString: function () {
            return data.join(", ");
        }
    };
};
//require('../_002 AddDeleteInList');

describe("All tests", function () {
    let arr;
    beforeEach(function () {
        arr = listCreator();
    });

    describe("Testing data", function () {
        it("Is empty", function () {
            expect(arr.data).to.be.equal(undefined);
        });
    });

    describe("Testing add", function () {
        it("Adds empty", function () {
            arr.add('');
            expect(arr.toString()).to.be.equal('');
        });
        it("Adds string", function () {
            arr.add('test');
            expect(arr.toString()).to.be.equal('test');
        });
        it("Adds array", function () {
            arr.add([1, 2, 3]);
            expect(arr.toString()).to.be.equal('1,2,3');
        });
        it("Adds string and int", function () {
            arr.add('test');
            arr.add(123);
            expect(arr.toString()).to.be.equal('test, 123');
        });
    });

    describe("Testing delete", function () {
        it("Delete with string", function () {
            expect(arr.delete('asd')).to.be.equal(undefined);
        });
        it("Delete with invalid index -1.1", function () {
            expect(arr.delete(-1.1)).to.be.equal(undefined);
        });
        it("Delete with invalid index -10", function () {
            expect(arr.delete(-10)).to.be.equal(undefined);
        });
        it("Delete with invalid index 1000", function () {
            expect(arr.delete(1000)).to.be.equal(undefined);
        });
        it("Delete with valid index", function () {
            arr.add('test');
            expect(arr.delete(0)).to.be.equal('test');
        });
        it("Delete with valid index", function () {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            expect(arr.delete(1)).to.be.equal(2);
        });
        it("Delete with valid index", function () {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.delete(1);
            expect(arr.toString()).to.be.equal('1, 3');
        });
    });

    describe("Testing toString", function () {
        it("With no data", function () {
            expect(arr.toString()).to.be.equal('');
        });
    });
});
