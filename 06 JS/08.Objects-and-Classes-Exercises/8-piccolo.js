function solve(input) {
    let parking = [];
    for (let i = 0; i < input.length; i++) {
        let pair = input[i].split(', ');
        let command = pair[0];
        let number = pair[1];
        if (command === 'IN'){
           
                if (!parking.includes(number)){

                    parking.push(number);
                }
            
        }else {
                let numberToRemove = number;
               parking = parking.filter(number => number !== numberToRemove);
        }
    }

    if (parking.length > 0) {
        parking = parking.sort((a, b) => a.localeCompare(b))
        .forEach(number => console.log(number));
        
    }else {
        console.log("Parking Lot is Empty");
    }
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);