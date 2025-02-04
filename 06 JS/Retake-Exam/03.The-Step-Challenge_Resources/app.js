
const baseUrl = 'http://localhost:3030/jsonstore/records';

const nameElement = document.getElementById('p-name');
const stepsElement = document.getElementById('steps');
const caloriesElement = document.getElementById('calories');

const addRecordBtn = document.getElementById('add-record');
const editRecordBtn = document.getElementById('edit-record');

const loadRecordsBtn = document.getElementById('load-records');
const recordListElement = document.getElementById('list');
const formContainerElement = document.getElementById('form');



const getRecords = async () => {

    const response = await fetch(baseUrl);
    let data = await response.json();
    data = Object.values(data);
    //console.log(data);

    recordListElement.innerHTML = '';

    for (const record of data) {

        const nameP = document.createElement('p');
        nameP.textContent = record.name;
        const stepsP = document.createElement('p');
        stepsP.textContent = record.steps;
        const caloriesP = document.createElement('p');
        caloriesP.textContent = record.calories;

        const infoDiv = document.createElement('div');
        infoDiv.classList.add('info');
        infoDiv.appendChild(nameP);
        infoDiv.appendChild(stepsP);
        infoDiv.appendChild(caloriesP);

        const changeBtn = document.createElement('button');
        changeBtn.classList.add('change-btn');
        changeBtn.textContent = 'Change';
        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = 'Delete';

        const buttonContainer = document.createElement('div');
        buttonContainer.classList.add('btn-wrapper');
        buttonContainer.appendChild(changeBtn);
        buttonContainer.appendChild(deleteBtn);

        const recordLi = document.createElement('li');
        recordLi.classList.add('record');
        recordLi.appendChild(infoDiv);
        recordLi.appendChild(buttonContainer);

        recordListElement.appendChild(recordLi);
        infoDiv.setAttribute('recordId', record._id);


        changeBtn.addEventListener('click', () => {

            nameElement.value = record.name;
            stepsElement.value = record.steps;
            caloriesElement.value = record.calories;

            recordListElement.removeChild(recordLi);

            formContainerElement.setAttribute('data-id', record._id);

            addRecordBtn.disabled = true;
            editRecordBtn.disabled = false;

        });

        deleteBtn.addEventListener('click', async () => {

            await fetch(`${baseUrl}/${record._id}`, {
                method: 'DELETE',
            });

            recordListElement.removeChild(recordLi);
        })

    }
}

loadRecordsBtn.addEventListener('click', getRecords);


addRecordBtn.addEventListener('click', async () => {

    let newRecord = {
        name: nameElement.value,
        steps: stepsElement.value,
        calories: caloriesElement.value,
    }

    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newRecord),
    })

    nameElement.value = '';
    stepsElement.value = '';
    caloriesElement.value = '';

    await getRecords();

});

editRecordBtn.addEventListener('click', async () => {

    const recordId = formContainerElement.getAttribute('data-id');

    const response = await fetch(`${baseUrl}/${recordId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: recordId,
            name: nameElement.value,
            steps: stepsElement.value,
            calories: caloriesElement.value,
        })
    })

    formContainerElement.removeAttribute('data-id');

    addRecordBtn.disabled = false;
    editRecordBtn.disabled = true;

    nameElement.value = '';
    stepsElement.value = '';
    caloriesElement.value = '';

    getRecords();
})