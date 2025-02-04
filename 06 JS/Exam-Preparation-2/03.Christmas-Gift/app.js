const baseUrl = 'http://localhost:3030/jsonstore/gifts';

const presentElement = document.getElementById('gift');
const forElement = document.getElementById('for');
const priceElement = document.getElementById('price');
const addPresentBtn = document.getElementById('add-present');
const editPresentBtn = document.getElementById('edit-present');

const loadBtn = document.getElementById('load-presents');
const giftListElement = document.getElementById('gift-list');
const formContainerElement = document.getElementById('form');

const getPresents = async () => {

    const response = await fetch(baseUrl);
    let data = await response.json();
    data = Object.values(data);
    console.log(data);

    giftListElement.innerHTML = '';

    for (const present of data) {

        const presentP = document.createElement('p');
        presentP.textContent = present.gift;
        const forP = document.createElement('p');
        forP.textContent = present.for;
        const priceP = document.createElement('p');
        priceP.textContent = present.price;

        const content = document.createElement('div');
        content.classList.add('content');
        content.appendChild(presentP);
        content.appendChild(forP);
        content.appendChild(priceP);

        const changeBtn = document.createElement('button');
        changeBtn.classList.add('change-btn');
        changeBtn.textContent = 'Change';
        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = 'Delete';

        const buttonContainer = document.createElement('div');
        buttonContainer.classList.add('buttons-container');
        buttonContainer.appendChild(changeBtn);
        buttonContainer.appendChild(deleteBtn);

        const giftSock = document.createElement('div');
        giftSock.classList.add('gift-sock');
        giftSock.appendChild(content);
        giftSock.appendChild(buttonContainer);

        giftListElement.appendChild(giftSock);
        content.setAttribute('sockId', present._id);   //?

        changeBtn.addEventListener('click', () => {

            presentElement.value = present.gift;
            forElement.value = present.for;
            priceElement.value = present.price;

            giftListElement.removeChild(giftSock);

            formContainerElement.setAttribute('data-id', present._id);

            addPresentBtn.disabled = true;
            editPresentBtn.disabled = false;

        });

        deleteBtn.addEventListener('click', async () => {

            await fetch(`${baseUrl}/${present._id}`, {
                method: 'DELETE',
            });

            giftListElement.removeChild(giftSock);
        })
    }


}

loadBtn.addEventListener('click', getPresents);

addPresentBtn.addEventListener('click', async () => {

    let newPresent = {
        gift: presentElement.value,
        for: forElement.value,
        price: priceElement.value,
    }

    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newPresent),
    })

    presentElement.value = '';
    forElement.value = '';
    priceElement.value = '';

    await getPresents();

});

editPresentBtn.addEventListener('click', async () => {

    // let curPresent = {
    //     gift: presentElement.value,
    //     for: forElement.value,
    //     price: priceElement.value,
    // }

    const presentId = formContainerElement.getAttribute('data-id');

    const response = await fetch(`${baseUrl}/${presentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: presentId,
            gift: presentElement.value,
            for: forElement.value,
            price: priceElement.value,
        })
    })

    formContainerElement.removeAttribute('data-id');

    addPresentBtn.disabled = false;
    editPresentBtn.disabled = true;

    presentElement.value = '';
    forElement.value = '';
    priceElement.value = '';

    getPresents();
})