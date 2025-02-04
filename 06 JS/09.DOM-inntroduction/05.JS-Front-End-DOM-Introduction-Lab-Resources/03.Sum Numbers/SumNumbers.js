function calc() {
    
    const first = document.getElementById('num1').value;
    const second = document.getElementById('num2').value;
    const result = document.getElementById('sum');

   //let sum = Number(first.value) + Number(second.value);
    let sum = Number(first) + Number(second);
    result.value = sum;
}
