function addItem() {
    const itemsListElements = document.getElementById('items');
    const inputItemElement = document.getElementById('newItemText');

    const newElement = document.createElement('li');
    newElement.textContent = inputItemElement.value;
   
    const deleteLinkElement = document.createElement('a');
    deleteLinkElement.textContent = '[Delete]';
    deleteLinkElement.href = '#';

    deleteLinkElement.addEventListener('click' ,function() {
        newElement.remove();
    })

    newElement.appendChild(deleteLinkElement);

    itemsListElements.appendChild(newElement);

    inputItemElement.value = '';
}