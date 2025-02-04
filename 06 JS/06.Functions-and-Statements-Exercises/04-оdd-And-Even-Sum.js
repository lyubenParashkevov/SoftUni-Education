function printSum(number) {
    let digits;

   function splitNumber(number) {
        digits = number.toString()
        .split('')
        .map(Number);      
        return digits;
    }
    
    function getSum(digits) {
        let evenSum = 0;
        let oddSum = 0;
        
        for (let n of digits) {
            if (n % 2 === 0) {
                evenSum += n;
            }else {
                oddSum += n;
            }
        }
        return `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
        
    }
    splitNumber(number)
    getSum(digits)

    console.log(getSum(digits));
}

printSum(1000435);