function addAndSubtract(a, b, c) {

    let sum = (x, y) => x + y;
        
    

    let subtract = (m, n) => m - n;
    
    

    let result = subtract(sum(a, b), c);
    console.log(result);
}

addAndSubtract(23, 6, 10);