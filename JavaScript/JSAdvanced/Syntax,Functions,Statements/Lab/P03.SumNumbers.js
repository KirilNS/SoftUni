function solve(n,m){
    let result=0;
    let x=+n;
    let y=+m;

    for(let i = x ; i <= y; i++){
        result+=i;
    }

    return result;
}

console.log(solve("1","3"));

