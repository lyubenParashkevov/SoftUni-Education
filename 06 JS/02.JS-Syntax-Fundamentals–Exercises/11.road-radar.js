function radar(speed, area) {
    let status;
    let speedLimit;
    

    
    switch (area) {
        case 'motorway': {
            speedLimit = 130;
            break;
        }

        case 'interstate': {
            speedLimit = 90;
            break;
        }

        case 'city': {
            speedLimit = 50;
            break;
        }

        case 'residential': {
            speedLimit = 20;
            break;
        }
    }

    let difference = speed - speedLimit;
    if (difference > 0 && difference <= 20) {
        status = 'speeding';
    }else if (difference > 0 && difference <= 40) {
        status = 'excessive speeding';
    }else if (difference > 0 && difference > 40) {
        status = 'reckless driving';
    }else {
        status = 'normal';
    }


    if (status == 'normal') {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }

    else {
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`)
    }
}

radar(40, 'city')