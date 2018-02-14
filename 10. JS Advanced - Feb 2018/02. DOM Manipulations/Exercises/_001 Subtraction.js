function subtract() {
    let num1 = Number(document.getElementById('firstNumber').value);
    let num2 = Number(document.getElementById('secondNumber').value);
    let print = document.getElementById('result');
    let result = num1 - num2;
    print.textContent = result;
}