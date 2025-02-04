
    function printMessage(number) {
        let sum = 0;

        solve(number);
        if (sum === number) {
            console.log('We have a perfect number!');
        }else {
            console.log("It's not so perfect.")
        }

        function solve(number) {
            for (let i = 1; i < number; i++) {
        
                if (number % i === 0) {
                    
                    sum += i;
                }
            }
            return sum;
        }
    }

printMessage(6);
printMessage(28);
printMessage(1236498);