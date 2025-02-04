function attachEventsListeners() {

    const days = document.getElementById('days');
    const daysButton = document.getElementById('daysBtn')
    const hours = document.getElementById('hours');
    const hoursButton = document.getElementById('hoursBtn')
    const minutes = document.getElementById('minutes');
    const minutesButton = document.getElementById('minutesBtn')
    const seconds = document.getElementById('seconds');
    const secondsButton = document.getElementById('secondsBtn')

    daysButton.addEventListener('click', daysConvert);
    hoursButton.addEventListener('click', hoursConvert);
    minutesButton.addEventListener('click', minutesConvert);
    secondsButton.addEventListener('click', secondsConvert);

    function daysConvert() {
        hours.value = days.value * 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }

    function hoursConvert() {
        days.value = hours.value / 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }

    function minutesConvert() {
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
        seconds.value = minutes.value * 60;
    }

    function secondsConvert() {
        minutes.value = seconds.value / 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
    }

}