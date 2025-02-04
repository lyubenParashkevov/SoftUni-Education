function validate() {
    
    const emailElement = document.getElementById('email');
    let patern = new RegExp(/[a-z+]+@[a-z+]+\.[a-z]+/);

    emailElement.addEventListener('change', check);

    function check(e) {

        const element = e.currentTarget;

        if (!element.value.match(patern)) {
            element.classList.add('error')
        }else {
            element.classList.remove('error')
        }
    }
}

