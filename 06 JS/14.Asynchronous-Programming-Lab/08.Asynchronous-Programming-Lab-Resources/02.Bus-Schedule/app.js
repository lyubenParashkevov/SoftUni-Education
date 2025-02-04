function solve() {

    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule';

    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoElement = document.getElementById('info');
   // const startBusStop = 
    
   let curStop = 'depot';
   let arrivingAt = '';
    function depart() {
        departBtn.disabled = true
        arriveBtn.disabled = false;
        fetch(`${baseUrl}/${curStop}`)
        .then(res => res.json())
        .then(data => {//console.log(data[name]);

            infoElement.textContent = `Next stop ${data.name}`;
            arrivingAt = data.name
            curStop =  data.next;
            })
        .catch(() => console.log('Error'));
        
    }
    
    async function arrive() {
        departBtn.disabled = false
        arriveBtn.disabled = true;
        infoElement.textContent = `Arriving at ${arrivingAt}`;
    
        
    }

    return {
        depart,
        arrive
    };
}

let result = solve();