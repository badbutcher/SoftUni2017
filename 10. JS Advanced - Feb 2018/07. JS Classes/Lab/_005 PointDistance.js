class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        let num1 = Math.pow(a.x - b.x, 2);
        let num2 = Math.pow(a.y - b.y, 2);
        return Math.sqrt(num1 + num2);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
