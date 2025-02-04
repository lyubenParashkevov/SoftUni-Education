


function printResult(num1, num2, operator) {

    const operation = getOperation(operator);

    const result = operation(num1, num2);

    console.log(result);

    function getOperation(operator) {

        switch (operator) {
            case 'divide':
                return (num1, num2) => num1 / num2;
    
            case 'multiply':
                return (num1, num2) => num1 * num2;
            
            case 'add':
                return (num1, num2) => num1 + num2;
            
            case 'subtract':
                return (num1, num2) => num1 - num2;
    
        }
    }

}

printResult(40,
    8,
    'divide'
)

