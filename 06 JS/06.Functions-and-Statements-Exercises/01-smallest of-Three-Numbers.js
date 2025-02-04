function printSmallestrNumber(a, b, c) {

    let min = Number.MAX_SAFE_INTEGER;

    function minNumber(numbers) {
        for(const number of numbers) {
            if (number < min) {
                min = number;
            }
        }

        return min;
    }
  
    let result = minNumber([a, b, c])

    console.log(result);

}

printSmallestrNumber(25, 21, 8);
    
   