function solve(numbers) {
    numbers.sort((a, b) => a - b);
    let sorted = [];
    while (numbers.length > 0) {

        sorted.push(numbers.shift());
        sorted.push(numbers.pop());
    }
    return(sorted);


}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])