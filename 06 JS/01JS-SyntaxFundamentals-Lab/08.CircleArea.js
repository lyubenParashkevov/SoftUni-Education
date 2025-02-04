
function calculateArea(argument){
    let result;
    if (typeof(argument) === "number"){
        result = Math.PI * argument ** 2;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(argument)}.`)
    }
}

calculateArea(5);
calculateArea("name");