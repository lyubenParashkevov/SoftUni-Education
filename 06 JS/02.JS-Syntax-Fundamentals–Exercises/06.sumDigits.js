function sumDigits(num) {
    let sum = 0;
    let curNum = 0;
    let numAsString = '';
    while (num > 0) {
       
        curNum = num % 10;
        sum += curNum;
       num = Math.trunc(num / 10)
    }

    console.log(sum);
}

sumDigits(543)