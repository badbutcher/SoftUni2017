function fibonacci() {
    let first = 0;
    let second = 1;
    return function () {
        let sum = first + second;
        first = second;
        second = sum;
        return first;
    };
}

let fib = fibonacci();
fib();
fib();
fib();
fib();
fib();


