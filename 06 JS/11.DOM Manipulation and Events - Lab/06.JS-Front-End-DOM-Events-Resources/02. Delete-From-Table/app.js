function deleteByEmail() {

    const tableRows = document.querySelectorAll('tbody tr');
    let searchElement = document.getElementsByName('email')[0];
    const result = document.getElementById('result');

    let list = Array.from(tableRows);

    for (const trow of list) {
        let mail = trow.children[1].textContent;
        if (mail.includes(searchElement.value)) {

            trow.parentElement.removeChild(trow);
            result.textContent = 'Deleted.';
            searchElement.value = '';
            return;

        } else {
            result.textContent = 'Not found.';
        }

    }
}