class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();
        this.id = -1;
    }

    get data() {
        return this._data;
    }

    set data(value) {

        this._data = value;
    }

    get count() {
        return this.data.size;
    }

    add(entity) {
        let aKeys = Object.keys(entity).sort();
        let bKeys = Object.keys(this.props).sort();
        let keyDiff = aKeys.filter(x => !bKeys.includes(x));
        if (keyDiff.length !== 0) {
            throw new Error(`Property ${keyDiff[0]} is missing from the entity!`)
        }

        this.validate(entity);

        this.id++;
        this.data.set(this.id, entity);
        return this.id;
    }

    validate(entity) {
        for (let obj in entity) {
            let val = entity[obj];
            if (typeof val !== this.props[obj]) {
                throw new TypeError(`Property ${obj} is of incorrect type!`);
            }
        }
    }

    get(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        return this.data.get(id);
    }

    update(id, newEntity) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this.data.set(id, newEntity);
    }

    del(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this.data.delete(id);
    }
}

let props = {
    color: "string",
    length: "number"
};
let repo = new Repository(props);
repo.get(5);
