function addItem() {
    const itemList = document.getElementById('items');
    const inputTextElement = document.getElementById('newItemText');

    const newElement = document.createElement('li');
    newElement.textContent = inputTextElement.value;
    itemList.appendChild(newElement);

    inputTextElement.value = '';
}