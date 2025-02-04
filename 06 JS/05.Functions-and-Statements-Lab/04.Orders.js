
function printOrderSum(product, count) {
    let sum = 0;
    function getPrice(product) {
        let price;
        switch (product) {
            case 'coffee':
                price = 1.5;
                return price;
            case 'water':
                price = 1;
                return price;
            case 'coke':
                price = 1.4;
                return price;
            case 'snacks':
                price = 2;
                return price;
        }

    }
    sum = getPrice(product) * count;
    console.log(sum.toFixed(2));

}

printOrderSum("coffee", 2);