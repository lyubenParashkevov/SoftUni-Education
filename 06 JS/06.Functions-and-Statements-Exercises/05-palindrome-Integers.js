





function printTrueOrFalse(numbers) {

    numbers.forEach(checIfAreEqual);


    function checIfAreEqual(number) {

        let isFalse = false;
        let numAssArr = number.toString().split('').map(Number);
        while (numAssArr.length > 0 && numAssArr.length != 1) {

            if (numAssArr.shift() !== numAssArr.pop()) {

                break;
            } else {
                isFalse = true;
            }
        }
        if (isFalse) {
            console.log('true');
        } else {
            console.log('false');
        }
    }

}

printTrueOrFalse([123, 323, 421, 121]);