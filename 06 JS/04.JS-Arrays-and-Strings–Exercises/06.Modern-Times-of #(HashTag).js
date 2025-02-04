function solve(text) {
    let textArr = text.split(' ');
    for (let i = 0; i < textArr.length; i++) {
        if (textArr[i].startsWith('#') && textArr[i].length > 1) {
            let specialWord = textArr[i].slice(1, textArr[i].length);

            let regex = /^[a-zA-Z]+$/;

            if (regex.test(specialWord)){
                console.log(specialWord);

            }
        }
    }
}

solve('The symbol # is known #vari6ously in English-speaking #regions as the #number sign');