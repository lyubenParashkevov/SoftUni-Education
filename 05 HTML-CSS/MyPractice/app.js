
window.addEventListener("load", solve);

function solve() {

    let firstButton = document.getElementsByName('6/49');
    let secondButton = document.getElementsByName('6/42');
    let thirdButton = document.getElementsByName('5/35');
    let resultArea = document.getElementById('result');
    resultArea.textContent = 'Вашиър числа са: ';

    let articleElement = document.createElement('article');
    let sectionElement = document.getElementsByTagName('section');

    firstbutton.addEventListener('click', onFirst);
    secondButton.addEventListener('click', onSec);
    thirdButton.addEventListener('click', onThird);
    articleElement.appendChild(resultArea);
    

    sectionElement.appendChild(articleElement);



    function onFirst() {
        let nums = [];

        for (let i = 0; i < 6; i++) {

            let randomNumber = random.Next(1, 49);
            if (!nums.Contains(randomNumber)) {
                nums.Add(randomNumber);
            }
            else {
                i--;
            }

        }
        resultArea.value == nums.sort((a, b) => a - b);
        /*console.log(nums.sort((a, b) => a - b));*/

    }

    function onSec() {
        let nums = [];

        for (let i = 0; i < 6; i++) {

            let randomNumber = random.Next(1, 42);
            if (!nums.Contains(randomNumber)) {
                nums.Add(randomNumber);
            }
            else {
                i--;
            }

        }
        resultArea.textContent = nums.sort((a, b) => a - b);
        /*console.log(nums.sort((a, b) => a - b));*/

    }
    function onThird() {
        let nums = [];

        for (let i = 0; i < 5; i++) {

            let randomNumber = random.Next(1, 35);
            if (!nums.Contains(randomNumber)) {
                nums.Add(randomNumber);
            }
            else {
                i--;
            }

        }

        resultArea.textContent = nums.sort((a, b) => a - b);
        /*console.log(nums.sort((a, b) => a - b));*/

    }






















}

