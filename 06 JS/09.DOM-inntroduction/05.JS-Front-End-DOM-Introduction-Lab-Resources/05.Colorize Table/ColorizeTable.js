function colorize() {
    const inputRows = document.querySelectorAll('table tr');
    let index = 0;
    for (const row of inputRows) {
        index++;
        if (index % 2 ===0) {
            row.style.background = 'Teal';
        }
    }
}