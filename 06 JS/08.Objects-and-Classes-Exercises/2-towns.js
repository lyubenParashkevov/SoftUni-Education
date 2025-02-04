function solve(input) {
    for (let line of input) {
        [town, latitude, longitude] = line.split(' | ');
        const city = {
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }
        console.log(city);
    }

}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);

//{ town: 'Sofia', latitude: '42.70', longitude: '23.33' }
//{ town: 'Beijing', latitude: '39.91', longitude: '116.36' }
