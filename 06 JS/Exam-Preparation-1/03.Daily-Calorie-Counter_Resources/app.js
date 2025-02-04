
const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const foodInputElement = document.getElementById('food');
const timeInputElement = document.getElementById('time');
const caloriesInputElement = document.getElementById('calories');

const addMealBtn = document.getElementById('add-meal');
const editMealBtn = document.getElementById('edit-meal');
const loadMealBtn = document.getElementById('load-meals');

const formElement = document.getElementById('form');

const mealsList = document.getElementById('list');

const loadMeals = async () => {
    const respond = await fetch(baseUrl);
    let data = await respond.json();

    console.log(Object.values(data));
    mealsList.innerHTML = '';

    for (const meal of Object.values(data)) {
        const changeBtn = document.createElement('button');
        changeBtn.classList.add('change-meal');
        changeBtn.textContent = 'Change';

        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-meal');
        deleteBtn.textContent = 'Delete';

        const mealbuttons = document.createElement('div');
        mealbuttons.id = 'meal-buttons';
        mealbuttons.appendChild(changeBtn);
        mealbuttons.appendChild(deleteBtn);

        const productNameData = document.createElement('h2');
        productNameData.textContent = meal.food;
        const timeData = document.createElement('h3');
        timeData.textContent = meal.time;
        const caloriesData = document.createElement('h2');
        caloriesData.textContent = meal.calories;

        const mealDiv = document.createElement('div');
        mealDiv.classList.add('meal');

        mealDiv.appendChild(productNameData);
        mealDiv.appendChild(timeData);
        mealDiv.appendChild(caloriesData);
        mealDiv.appendChild(mealbuttons);

        mealsList.appendChild(mealDiv);

        changeBtn.addEventListener('click', () => {
            
            formElement.setAttribute('data-id', meal._id);
            foodInputElement.value = meal.name;
            timeInputElement.value = meal.time;
            caloriesInputElement.value = meal.calories;

            mealsList.removeChild(mealDiv);

            editMealBtn.disabled = false;
            addMealBtn.disabled = true;

        });

        deleteBtn.addEventListener('click', async () => {
            // delete http request
            await fetch(`${baseUrl}/${meal._id}`, {
                method: 'DELETE'
            });

            // remove from list
            mealsList.removeChild(mealDiv);
        });
        
    }
}

loadMealBtn.addEventListener('click', loadMeals);


editMealBtn.addEventListener('click', async () => {

    const newMeal = {
        food: foodInputElement.value,
        time: timeInputElement.value,
        calories: caloriesInputElement.value,
    }

    const mealId = formElement.getAttribute('data-id');
    
    const response = await fetch(`${baseUrl}/${mealId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: mealId,
            food,
            calories,
            time,
        })
    });
    if (!response.ok) {
        return;
    }

    editMealBtn.disabled = true;
    addMealBtn.disabled = false;

    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
    loadMeals();

})






