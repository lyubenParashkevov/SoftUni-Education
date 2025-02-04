function buyFruit(type, weight, priceKg) {
    weight /= 1000;
    let sum =  weight * priceKg;
    
    console.log(`I need $${sum.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${type}.`);
}

buyFruit('orange', 2500, 1.80)