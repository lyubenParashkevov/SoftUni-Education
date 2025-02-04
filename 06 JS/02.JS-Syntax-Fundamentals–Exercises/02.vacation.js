function getPrice(number, type, day) {
    let total;
    let priceForDay;

    if(type == 'Students') {
        if(day == 'Friday') {
            priceForDay = 8.45;
        }else if(day == 'Saturday') {
            priceForDay = 9.80;
        }else{
            priceForDay = 10.46;
        }
       
        if(number >= 30) {
           priceForDay -= priceForDay * 0.15;
        }
    }
    else if(type == 'Business') {
        if(day == 'Friday') {
            priceForDay = 10.90;
        }else if(day == 'Saturday') {
            priceForDay = 15.60;
        }else{
            priceForDay = 16;
        }
        if(number >= 100) {
            number -= 10;
        }

    }

    else {
        if(day == 'Friday') {
            priceForDay = 15;
        }else if(day == 'Saturday') {
            priceForDay = 20;
        }else{
            priceForDay = 22.50;
        }
        if(number > 9 && number < 21) {
            priceForDay -= priceForDay * 0.05;
        }
    }

    total = number * priceForDay;
    console.log(`Total price: ${total.toFixed(2)}`);
}

getPrice(40,
    "Regular",
    "Saturday"
    )
   
    
    