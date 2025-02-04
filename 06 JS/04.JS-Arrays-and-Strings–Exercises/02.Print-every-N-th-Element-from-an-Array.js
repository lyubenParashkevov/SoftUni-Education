function solve(arr, step) {
    let reducedArr = [];

    for (let i = 0; i < arr.length; i+= step) {
        reducedArr.push(arr[i])
    }
    return(reducedArr);

}

solve(['dsa',
'asd', 
'test', 
'tset'], 
2
)
 
 
 
