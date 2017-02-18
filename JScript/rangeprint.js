

function printRange(start, end, skip=1){
    if(end === undefined) {end =  start; start = 0;}
    while(start < end){
        console.log(start);
        start += skip;
    }
    
}


printRange(-2, 4);  