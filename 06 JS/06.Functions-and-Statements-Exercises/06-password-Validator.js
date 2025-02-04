function validatePassword (password) {
    const validateLength = password => password.length >= 6 && password.length <= 10;
    const validateSymbols = password => /^[a-zA-Z0-9]+$/.test(password);
    const validateTwoDigits =password => password
    .split('')
    .filter(character => Number.isInteger(Number(character)))
    .length >= 2;

    let isValid = true;

    if (!validateLength(password)) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }

    if (!validateSymbols(password)) {
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }

    if (!validateTwoDigits(password)) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }
    if (isValid) {
        console.log("Password is valid");
    }

}

validatePassword('logIn');
validatePassword('MyPass123');
validatePassword('Pa$s$s');