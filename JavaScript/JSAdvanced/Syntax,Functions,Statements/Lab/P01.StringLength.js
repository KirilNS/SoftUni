function StringLength(firstString,secondString,thirdString){
    let sum=firstString.length+secondString.length+thirdString.length;
    let avg=Math.floor(sum/3);

    console.log(sum);
    console.log(avg);
}

StringLength("Max","Kiro","Ivan");