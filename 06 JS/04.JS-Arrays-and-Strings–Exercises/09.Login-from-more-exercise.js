function solve(passwords) {
    let username = passwords[0];
    let counter = 0;
    for (let i = 1; i < passwords.length; i++) {
        let reversed = passwords[i].split('').reverse().join('');
        if (reversed !== username) {
            if (i <= 3) {
                console.log("Incorrect password. Try again.");

            }else {
                console.log(`User ${username} blocked!`)
                return;
            }
        }

        else {
            console.log(`User ${username} logged in.`)
        }

    }
}

solve(['sunny','rainy','cloudy','sunny','not sunny']);

