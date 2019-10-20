function calculateVAT( numbers){
    let sum=0;
    for(let num of numbers){
       sum+=num; 
    }
    console.log('sum = '+ sum);
    console.log('VAT = '+ sum*0.20);
    console.log('total = '+ sum*1.2);

}

let numbers=[1.20, 2.60, 3.50]
calculateVAT(numbers)