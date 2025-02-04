function sumTable() {

    const inputRows = document.querySelectorAll('table tr');
    const sumElement = document.getElementById('sum');
    let sum = 0;
    for (let i = 1; i < inputRows.length; i++) {
        let cols = inputRows[i].children;
        sum += Number(cols[1].textContent)
        
    }

    sumElement.textContent = sum;
}