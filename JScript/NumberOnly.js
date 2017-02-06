/*R- remove all non-number
  I - array with mixed items
  O - array with just Numbers
  T 
  
  Walk:
*/

function numbersOnly(arr){
    var newArray = [];
    for( var i = 0; i < arr.length; i++ ) {
        if( typeof arr[i] == "number")
            newArray.push(arr[i]);
    }
    return newArray;    
}


var newArray = numbersOnly([1, "apple", -3, "orange", 0.5]);

console.log(newArray);

console.log((1 == true));  //true
console.log((2 == "2"));   // true
console.log(("hello" == 'hello')); //true
console.log((!false));  // true
console.log((Math && console));  //true
console.log((1 && "")); //false
console.log((null || undefined)); //false;