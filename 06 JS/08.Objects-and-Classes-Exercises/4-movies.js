function solve(input) {
    let movies = [];

    for (const row of input) {
        let addMovieCommand = 'addMovie';
        let directedByCommand = 'directedBy';
        let onDateCommand = 'onDate';

        if (row.includes(addMovieCommand)) {
            let movie = {
                name: row.substring(addMovieCommand.length + 1),
            }

            movies.push(movie);

        } else if (row.includes(directedByCommand)) {

            const [movieName, director] = row.split(` ${directedByCommand} `)
            const movie = movies.find((movie) => movie.name === movieName);

            if (movie) {
                movie.director = director;
            }

        } else if (row.includes(onDateCommand)) {
            const [movieName, date] = row.split(` ${onDateCommand} `);

            const movie = movies.find((movie) => movie.name === movieName);

            if (movie) {
                movie.date = date;
            }
        }

    }

    movies.filter(movie => movie.director && movie.date)
    .forEach(movie => console.log(JSON.stringify(movie)));
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);

//{"name":"Fast and Furious","date":"30.07.2018","director":"Rob Cohen"}
//{"name":"Godfather","director":"Francis Ford Coppola","date":"29.07.2018"}
