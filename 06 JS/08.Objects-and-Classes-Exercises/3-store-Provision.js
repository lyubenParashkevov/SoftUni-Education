function solve(first, second) {

    let store = [];

    while (first.length > 0) {
        [productName, count] = [first.shift(), Number(first.shift())];

        store[productName] = count;

    }

    while (second.length > 0) {
        [productName, count] = [second.shift(), Number(second.shift())];
        if (!store[productName]) {
            store[productName] = 0;
        }
        store[productName] += count;

    }

    for (const product in store) {
        console.log(`${product} -> ${store[product]}`);

    }

}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);


