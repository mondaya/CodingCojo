"use strict";

var totalQuarters;

function randomChance(numQuarters, limit) {
  var probability = 0;  /* will be 1 to 100 */
  var payout = 0;  /* will be 50 to 99 */
  var total = 0;

 while (numQuarters > 0) {
    numQuarters--;
    probability = Math.floor(Math.random()*100+1);
//    console.log(probability, numQuarters, payout);
    if (probability == 100) {
      payout = Math.floor(Math.random()*51+50);
      console.log("paid out",payout);
      total = numQuarters + payout;
      if (limit > 0 && total < limit) {
        continue;
      }
      break;
    }
  }
  console.log(probability, numQuarters, payout);
  return total;
}

//totalQuarters(75, 200);