function printSubstraction(input) {
    let even = [];
    let odd = [];
    let oddSum = 0;
    let evenSum = 0;
    for (let num of input) {
        if (num % 2 === 0) {
            evenSum += num;
        }else {
            oddSum += num;
        }
    }


        console.log(evenSum - oddSum);
}

printSubstraction([30,5,7,9]);