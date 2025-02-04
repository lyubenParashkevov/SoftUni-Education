   
    
    function solve(number) {   
        for (let i = 0; i < number; i++) {        
            console.log(createRow(number));
            result = '';
        }
        function createRow(number) {
            let result = '';
            for (let j = 0; j < number; j++) {            
                result += number + " ";
            }
            return result;
        }

    }
    
solve(3);
solve(7);