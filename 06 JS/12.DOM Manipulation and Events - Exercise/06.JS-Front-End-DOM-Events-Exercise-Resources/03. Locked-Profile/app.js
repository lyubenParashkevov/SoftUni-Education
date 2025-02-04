function lockedProfile() {

    const buttons = Array.from(document.getElementsByTagName('button'));
   
    for (const button of buttons) {
        button.addEventListener('click', solve);

    }

    function solve(event) {
        let btn = event.target;
        let profile = btn.parentElement;
        let elementToShow = profile.getElementsByTagName('div')[0];

        let unlocked = profile.querySelector('input[value=unlock]');

        if (!unlocked.checked) {
            return;
        }

        if (btn.textContent === 'Show more') {
            elementToShow.style.display = 'block';
            btn.textContent = 'Hide it';
        }else {
            elementToShow.style.display = 'none';
            btn.textContent = 'Show more';

        }

    }

}