var arr1 = ["James", "Jill", "Jane", "Jack"];

function fancyArray(symbol, array, reversed) {
  var i = 0;
  if (reversed) {
    for (i = array.length-1; i>=0; i--) {
      console.log(i,symbol,array[i]);
    }
  }
  else {
    for (i = 0; i < array.length; i++) {
      console.log(i,symbol,array[i]);
    }
  }
}

fancyArray("->", arr1, true);
fancyArray("=>", arr1, false);
fancyArray("::", arr1, true);
fancyArray("----", arr1, false);