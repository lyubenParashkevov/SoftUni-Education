

function cook(number, ...operations) {

    let result = Number(number);
    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case 'chop':
                result /= 2;
                break;
            case 'dice':
                result = Math.sqrt(result);
                break;
            case 'spice':
                result += 1;
                break;
            case 'bake':
                result *= 3;
                break;
            case 'fillet':
                result -= result * 0.2;
                break;        
        }

        console.log(result);

    }
}



cook('32', 'chop', 'chop', 'chop', 'chop', 'chop')