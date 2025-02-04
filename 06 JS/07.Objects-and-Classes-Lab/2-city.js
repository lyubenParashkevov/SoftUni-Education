function solve(obj) {
    Object.keys(obj)
    .forEach(propName => console.log(`${propName} -> ${obj[propName]}`));
}

solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
)
