function solve(input) {

    let cats = [];
    class Cat {
        constructor(catName, age) {
            this.catName = catName;
            this.age = age;
        }

        meow() {
            console.log(`${this.catName}, age ${this.age} says Meow`);
        }
    }

    for (let i = 0; i < input.length; i++) {
        let catInfo = input[i].split(' ');
        let name = catInfo[0];
        let age = catInfo[1];
        cats.push(new Cat(name, age));
    }
    for (let cat of cats) {
        cat.meow();
    }

}

solve(['Mellow 2', 'Tom 5'])