function addItem() {
    
    const textElement = document.getElementById('newItemText');
    const valueElement = document.getElementById('newItemValue');
    const selectElement = document.getElementById('menu');
    let optionElement = document.createElement('option');

    optionElement.textContent = textElement.value;
    optionElement.value = valueElement.value;
    if (textElement.value !== '' && valueElement.value !== '') {

        selectElement.appendChild(optionElement);
    }
    textElement.value = '';
    valueElement.value = '';
}