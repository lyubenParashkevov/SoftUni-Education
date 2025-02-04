//const bookUrl = 'http://localhost:3030/jsonstore';
//
//fetch(`${bookUrl}/books`)
//    .then(res => res.json())
//    .then(data => console.log(data))
//    .catch(err => console.log('error'));
//
//const url = 'https://swapi.dev/api';
//
//// Promise chaining
//fetch(`${url}/people/1`)
//    .then(response => response.json())
//    .then(data => console.log(data))
//    .catch(error => console.log('Something went wrong'));
//
//
//fetch(`${bookUrl}/books`, {
//    method: 'POST',
//    headers: {
//        'content-type': 'aplication/json'
//
//    },
//    body: JSON.stringify({
//        title: 'Baba Jaga',
//        author: 'Djado Torbalan'
//
//    })
//})
//.then(res => res.json())
//.then(data => console.log(data))
//.catch(err => console.log('Nqma jaga'));
//

function resolveAfter2Seconds() {
    return new Promise(resolve => {
    setTimeout(() => {
    resolve('resolved');
    }, 2000);
    });
}

async function asyncCall() {
    console.log('calling');
    let result = await resolveAfter2Seconds();
    console.log(result);
    }

asyncCall();    