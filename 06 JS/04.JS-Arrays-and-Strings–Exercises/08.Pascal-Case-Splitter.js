function solve(input) {

   let patern = /([A-Z][a-z]*)/g;
   let maches = input.match(patern).join(', ');
   console.log(maches);
}


solve('SplitMeIfYouCanHaHaYouCantOrYouCan');