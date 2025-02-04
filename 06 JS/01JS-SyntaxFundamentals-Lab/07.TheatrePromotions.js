
function printPrice(weekday, age) {
    if (age >= 0 && age <= 18) {
        if (weekday == "Weekday") {
            console.log("12$");

        }
        else if (weekday == "Weekend") {
            console.log("15$");
        }
        else {
            console.log("5$");
        }

    }
    else if (age > 18 && age <= 64) {
        if (weekday == "Weekday") {
            console.log("18$");

        }
        else if (weekday == "Weekend") {
            console.log("20$");
        }
        else {
            console.log("12$");
        }

    }
    else if(age > 64 && age <= 122){
        if (weekday == "Weekday") {
            console.log("12$");

        }
        else if (weekday == "Weekend") {
            console.log("15$");
        }
        else {
            console.log("10$");
        }
    }

    else{
        console.log("Error!");
    }
}

printPrice('Weekday',42);
printPrice('Holiday', -12);
printPrice('Holiday', 15);

