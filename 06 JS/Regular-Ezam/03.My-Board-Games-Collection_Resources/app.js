const baseUrl = 'http://localhost:3030/jsonstore/games';

const loadButtonElement = document.getElementById('load-games');
const addGameButtonElement = document.getElementById('add-game');
const editGameButtonElement = document.getElementById('edit-game');

const gameInputElement = document.getElementById('g-name');
const tipeInputElement = document.getElementById('tipe');
const playersInputElement = document.getElementById('players');
const formElement = document.getElementById('form');

const loadGame = async () => {
    // Fetch all meals
    const response = await fetch(baseUrl);
    const data = await response.json();












    
}
