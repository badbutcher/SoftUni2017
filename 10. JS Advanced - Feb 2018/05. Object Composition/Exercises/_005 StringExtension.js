(function StringExtension() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return this.length === 0 || this === null;
    };

    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.toString();
        } else {
            if (n <= 3) {
                return '.'.repeat(n);
            }

            let lastSpace = this.toString().substr(0, n - 2).lastIndexOf(" ");

            if (lastSpace === -1) {
                lastSpace = n - 3;
            }

            return this.toString().substr(0, lastSpace) + '...';
        }
    };

    String.format = function (input, ...params) {
        let placeholders = input;

        for (let i = 0; i < params.length; i++) {
            let re = new RegExp(`\\{${i}\\}`);
            placeholders = placeholders.replace(re, params[i]);
        }

        return placeholders;
    };
})();

let str = 'the quick brown fox jumps over the lazy dog';
console.log(str);
str = str.truncate(10);
console.log(str);
str = str.truncate(25);
console.log(str);
str = str.truncate(43);
console.log(str);
str = str.truncate(45);
console.log(str);
console.log();
console.log();
let testString = 'the quick brown fox jumps over the lazy dog';
console.log(testString);
testString = testString.truncate(6);
console.log(testString);
testString = testString.truncate(12);
console.log(testString);