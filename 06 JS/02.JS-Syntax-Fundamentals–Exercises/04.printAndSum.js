function printSum(num1, num2) {
    let sum = 0;
    let sumAsString = '';
    for (let i = num1; i <= num2; i++) {
        sum += i;
        sumAsString += (i.toString() +' ')
    }
    console.log(sumAsString);
    console.log(`Sum: ${sum}`);
}

printSum(0, 26)
