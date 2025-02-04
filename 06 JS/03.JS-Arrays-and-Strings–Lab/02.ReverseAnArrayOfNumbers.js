function solve(n, colection) {

    let toReverse = [];
    for (let i = 0; i < n; i++) {
        toReverse.push(colection[i])
    }

    //console.log(toReverse.reverse().join(' '));

    let reversedAsString = "";
    for (let i = toReverse.length - 1; i >=0; i--) {
      reversedAsString += toReverse[i] + " ";     
    }

    console.log(reversedAsString);
}

solve(3, [10, 20, 30, 40, 50]);