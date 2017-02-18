var numberOfDays = 30;
var previousAmount = 1;

var totals = 0;
for(var i = 2; i <= numberOfDays;  i++){
    previousAmount = (previousAmount + previousAmount);
    totals += previousAmount;
      
};

console.log("Total amount:" , (totals * 0.01))

function howMayDaysToFewBillion(DollorAmt){
    var amount = 1;
    var days = 1;
    var totals = 0;

    previousAmount = 1;
    while(true){
        days += 1;
        amount = (amount + amount);
        totals += amount;
        if( (totals * 0.01) >= DollorAmt)
            break;
        
    };

    console.log("Takes:" , days, "to get ", "$"+DollorAmt)
}


howMayDaysToFewBillion(10000);
howMayDaysToFewBillion(1000000000);
howMayDaysToFewBillion(Infinity);
