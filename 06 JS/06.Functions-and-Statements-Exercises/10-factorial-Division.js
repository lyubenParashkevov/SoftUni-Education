function solve(a, b) {

    function factorial(number) {
        let sum = 1;
        for (let i = 1; i <= number; i++) {
            sum *= i;
        }
        return sum;
    }

    const result =  factorial(a) / factorial(b);
    console.log(result.toFixed(2));
}

solve(5, 2);
solve(6, 2);