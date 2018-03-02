let chai = require('chai');
let jsdom = require('jsdom-global')();
let $ = require('jquery');
let expect = chai.expect;

document.body.innerHTML = `<div id="wrapper">
    <input type="text" id="name">
    <input type="text" id="income">
    </div>`;

let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};

describe('Shared object tests', function () {
    describe('Initial state', function () {
        it('Name should be null', function () {
            expect(sharedObject.name).to.be.equal(null);
        });
        it('Income should be null', function () {
            expect(sharedObject.income).to.be.equal(null);
        });
    });
    describe('Change Name', function () {
        it('Should not change name when empty', function () {
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.equal(null);
        });
        it('Number should change name', function () {
            sharedObject.changeName(51);
            expect(sharedObject.name).to.be.equal(51);
        });
        it('String should change name', function () {
            sharedObject.changeName('Pavel');
            expect(sharedObject.name).to.be.equal('Pavel');
        });
        it('Should not change name []', function () {
            sharedObject.changeName([]);
            expect(sharedObject.name).to.be.equal('Pavel');
        });
        it('Should not change name false', function () {
            sharedObject.changeName(false);
            expect(sharedObject.name).to.be.equal(false);
        });
        it('String should change name', function () {
            sharedObject.changeName('Losho');
            expect(sharedObject.name).to.be.equal('Losho');
        });

        describe('Change Name TextBox', function () {
            it('Should not change name when empty', function () {
                let textBox = $('#name');
                sharedObject.changeName('');
                expect(textBox.val()).to.be.equal('Losho');
            });
            it('Should not change name', function () {
                let textBox = $('#name');
                sharedObject.changeName([]);
                expect(textBox.val()).to.be.equal('Losho');
            });
            it('Should change name false', function () {
                let textBox = $('#name');
                sharedObject.changeName(false);
                expect(textBox.val()).to.be.equal('false');
            });
            it('Should change name', function () {
                let textBox = $('#name');
                sharedObject.changeName('Kamen');
                expect(textBox.val()).to.be.equal('Kamen');
            });
        });
    });

    describe('Change Income', function () {
        it('Should not change income when empty', function () {
            sharedObject.changeIncome('');
            expect(sharedObject.income).to.be.equal(null);
        });
        it('Should not change income when []', function () {
            sharedObject.changeIncome([]);
            expect(sharedObject.income).to.be.equal(null);
        });
        it('Number should change income', function () {
            sharedObject.changeIncome(100);
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Number should not change income', function () {
            sharedObject.changeIncome(-51);
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Income should not change', function () {
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Income should not change', function () {
            sharedObject.changeIncome(1.123);
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Income should not change', function () {
            sharedObject.changeIncome('asd');
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Number should change income', function () {
            sharedObject.changeIncome(200);
            expect(sharedObject.income).to.be.equal(200);
        });
        it('Number should not change income {}', function () {
            sharedObject.changeIncome({});
            expect(sharedObject.income).to.be.equal(200);
        });
        it('Number should not change income []', function () {
            sharedObject.changeIncome([]);
            expect(sharedObject.income).to.be.equal(200);
        });
        it('Number should not change income false', function () {
            sharedObject.changeIncome(false);
            expect(sharedObject.income).to.be.equal(200);
        });

        describe('Change Income TextBox', function () {
            it('Income should change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome(50);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome(-50);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome(0);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome(false);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome(1.123);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                sharedObject.changeIncome('asd');
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should change to new one', function () {
                sharedObject.changeIncome(44);
                let textBox = $('#income');
                sharedObject.changeIncome(66);
                expect(textBox.val()).to.be.equal('66');
            });
        });
    });

    describe('Update Name', function () {
        it('Should not change name when empty', function () {
            sharedObject.changeName('Pesho');
            let name = $('#name');
            name.val('');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Pesho');
        });
        it('Should not change name when false', function () {
            sharedObject.changeName('Pesho');
            let name = $('#name');
            name.val(false);
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('false');
        });
        it('Should change name', function () {
            sharedObject.changeName('Kamen');
            let name = $('#name');
            name.val('Pavel');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Pavel');
        });
    });

    describe('Update Income', function () {
        it('Income should not change when empty', function () {
            sharedObject.changeIncome(50);
            let name = $('#income');
            name.val('');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(50);
        });
        it('Income should not change when empty', function () {
            sharedObject.changeIncome(50);
            let name = $('#income');
            name.val(false);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(50);
        });
        it('Income change when', function () {
            sharedObject.changeIncome(123);
            let name = $('#income');
            name.val('Gosho');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(123);
        });
        it('Income should not change when negative', function () {
            sharedObject.changeIncome(-50);
            let name = $('#income');
            name.val(100);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(100);
        });
        it('Income should not change when 0', function () {
            sharedObject.changeIncome(0);
            let name = $('#income');
            name.val(33);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(33);
        });
        it('Income should not change when -10', function () {
            sharedObject.changeIncome(33);
            let name = $('#income');
            name.val(-10);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(33);
        });
        it('Income should not change for 1.123', function () {
            sharedObject.changeIncome(123);
            let name = $('#income');
            name.val(1.123);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(123);
        });
    });
});