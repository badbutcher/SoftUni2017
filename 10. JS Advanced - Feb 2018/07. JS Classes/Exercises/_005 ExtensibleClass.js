let extensible = (function () {
    let id = 0;
    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template) {
            for (let key in template) {
                if (template.hasOwnProperty(key)) {
                    let element = template[key];
                    if (typeof element === 'function') {
                        Extensible.prototype[key] = element
                    } else {
                        this[key] = element
                    }
                }
            }
        }
    };

    return Extensible;
})();


let obj1 = new extensible();
let obj2 = new extensible();
let obj3 = new extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
