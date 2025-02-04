function solve(input) {
    let shedule = {};
    for (const line of input) {

        let [day, name] = line.split(' ');
        if (shedule[day]){
            console.log(`Conflict on ${day}!`)
        }else {
            shedule[day] = name;
            console.log(`Scheduled for ${day}`)
        }
    }

    for (let meeting in shedule) {
        console.log(`${meeting} -> ${shedule[meeting]}`)
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);