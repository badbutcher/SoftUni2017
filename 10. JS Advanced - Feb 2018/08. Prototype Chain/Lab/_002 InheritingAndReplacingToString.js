function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            let className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            let className = this.constructor.name;
            return super.toString().slice(0, -1) + `, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            let className = this.constructor.name;
            return super.toString().slice(0, -1) + `, course: ${this.course})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }

}

// let obj = toStringExtension();
// module.exports = obj.Person;

module.exports = toStringExtension;

// let func = toStringExtension();
// let person = new func.Person('pavel', 'asd@asd');
// console.log(person.toString());
// let teacher = new func.Teacher('nikola', 'asd@asd', 'js');
// console.log(teacher.toString());