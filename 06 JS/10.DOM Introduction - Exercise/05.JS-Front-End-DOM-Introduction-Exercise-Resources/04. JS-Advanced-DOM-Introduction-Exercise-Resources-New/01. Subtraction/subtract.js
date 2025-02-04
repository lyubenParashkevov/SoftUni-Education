function subtract() {

    const firstInputNumber = document.getElementById('firstNumber');
    const secondInputNumber = document.getElementById('secondNumber');
    const resultInput = document.getElementById('result');

    const firstNum = Number(firstInputNumber.value);
    const secondNum = Number(secondInputNumber.value);
    const result = firstNum - secondNum;

    resultInput.textContent = result;
    console.log(resultInput);

}