function attachEvents() {
    const locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';
    const curentConditionUrl = 'http://localhost:3030/jsonstore/forecaster/locations';
    const threeDaysUrl = 'http://localhost:3030/jsonstore/forecaster/upcoming';

    const getWeatherBtn = document.getElementById('submit');
    const inputElement = document.getElementById('location');

    const symbols = {
        'Sunny': '☀',
        'Partly sunny':
    }
    getWeatherBtn.addEventListener('click', () => {
        fetch(`${locationsUrl}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
        })
        .catch(err => console.log('Error'));
    })






}




attachEvents();