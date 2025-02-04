function areEqual(num) {
    let curNum = 0;
    let sum = 0;
    let numToCompare = num % 10;
    let isEqual = true;
    while(num > 0) {
        curNum = num % 10;
        num = Math.trunc(num / 10);
        sum += curNum;
        if (curNum != numToCompare) {
            isEqual = false;
        }

    }

    console.log(isEqual);
    console.log(sum);
}

areEqual(1234);