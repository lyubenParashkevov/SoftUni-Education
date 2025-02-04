function solve(input) {
    let songs = [];

    class Song {
        constructor(typeList, songName, duration) {
            this.typeList = typeList;
            this.songName = songName;
            this.duration = duration;
        }
    }

    let n = input[0];
    let type = input[input.length - 1];

    for (let i = 1; i <= n; i++) {
        [typeList, songName, duration] = input[i].split('_');
        songs.push(new Song(typeList, songName, duration))
    }

    if (type === 'all') {
        songs.forEach((i) => console.log(i.songName));
    }else {
        let filtered = songs.filter((i) => i.typeList === type);
        filtered.forEach((i) => console.log(i.songName));
    }
}


//solve([3,
//    'favourite_DownTown_3:14',
//    'favourite_Kiss_4:16',
//    'favourite_Smooth Criminal_4:01',
//    'favourite']
//);

//solve([4,
//    'favourite_DownTown_3:14',
//    'listenLater_Andalouse_3:24',
//    'favourite_In To The Night_3:58',
//    'favourite_Live It Up_3:48',
//    'listenLater']
//);//

solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
);