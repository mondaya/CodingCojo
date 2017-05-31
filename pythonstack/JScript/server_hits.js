function isChessMoveSafe1(intendedMove , queenArr){
    
    var xCoord= 0, yCoord =  1;
    
    var safe = true;
    
    for ( var qNum = 0; qNum < queenArr.length; qNum++){
        
        for (var row = 0; row < 8; row++){
            if((intendedMove[xCoord] == row) 
                &&(intendedMove[yCoord] == queenArr[qNum][yCoord])) {safe = false;}
        }
        
        for (var col = 0; col < 8; col++){
            if((intendedMove[xCoord] == queenArr[qNum][xCoord]) 
                &&(intendedMove[yCoord] == col)) {safe = false;}
        }
        for (var lDiag = -7; lDiag <= 7; lDiag++){
            if((intendedMove[xCoord] - intendedMove[yCoord] == lDiag) 
                &&(queenArr[qNum][xCoord] - queenArr[qNum][yCoord] == lDiag )) {safe = false;}
        }
        for (var rDiag = 0; rDiag <= 14; rDiag++){
            if((intendedMove[xCoord] + intendedMove[yCoord] == rDiag) 
                &&(queenArr[qNum][xCoord] + queenArr[qNum][yCoord] == rDiag )) {safe = false;}
        }
    }
    
    
    return safe;
}

function queens1(nQueensLeft,results,queensSoFar){
    
    if(results === undefined ) { results = [];}
    if(queensSoFar === undefined)  { queensSoFar = [];}
    
    
    if (nQueensLeft) {
        //console.log(results);
        for (var row = 0; row < 8; row++){
            for (var col = 0; col < 8; col++){
               console.log(queensSoFar.length);
               if(isChessMoveSafe1([row, col], queensSoFar)){
                    var newQueen  = [row, col];
                    //queensSoFar = queensSoFar.concat([newQueen])
                    queens1(nQueensLeft - 1, results, queensSoFar.concat([newQueen]));
                    console.log(queensSoFar.length);
               }
            }
        }
    }else {results.push(queensSoFar);}
}


function queens2(nQueensLeft,results,queensSoFar){
    
    if(results === undefined ) { results = [];}
    if(queensSoFar === undefined)  { queensSoFar = [];}
    
    
    if (nQueensLeft) {
        //console.log(results);
        var row  = 0;
        if (queensSoFar.length){
            row = queensSoFar[queensSoFar.length -1][0];
        }
        for (; row < 8; row++){
            for (var col = 0; col < 8; col++){
               console.log(queensSoFar.length);
               if(isChessMoveSafe1([row, col], queensSoFar)){
                    var newQueen  = [row, col];
                    //queensSoFar = queensSoFar.concat([newQueen])
                    queens2(nQueensLeft - 1, results, queensSoFar.concat([newQueen]));
                    //console.log(queensSoFar.length);
               }
            }
        }
    }else {results.push(queensSoFar);}
}

function queens3(nQueensLeft,results,queensSoFar){
    
    if(results === undefined ) { results = [];}
    if(queensSoFar === undefined)  { queensSoFar = [];}
    
    
    if (nQueensLeft) {
        //console.log(results);
        var row  = 0;
        if (queensSoFar.length){
            row = queensSoFar[queensSoFar.length -1][0] + 1;
            console.log(row);
        }
        for (; row < 8; row++){
            for (var col = 0; col < 8; col++){
               
               if(isChessMoveSafe1([row, col], queensSoFar)){
                    var newQueen  = [row, col];
                    console.log(queensSoFar.length);                   
                    //queensSoFar = queensSoFar.concat([newQueen])
                    queens3(nQueensLeft - 1, results, queensSoFar.concat([newQueen]));
                    //console.log(queensSoFar);
               }
            }
        }
    }else {results.push(queensSoFar);}
}
//results = [];
//queens1(2, results, undefined);
//console.log(results);

function sum_array(array){
    var total = 0;
    for(var i = 0;  i < array.length;  i++)
        total += array[i];
    return total;
}

function dominations(results, domination, target, amount_in, domination_distr, domination_index){
    
    if(domination_index >=  domination.length || domination_index < 0)
        return;
    //console.log("in flight" , Object.values(domination_distr));
    if(amount_in > 0 && sum_array(domination_distr) == target){
        //console.log("pass" , Object.values(domination_distr));
        //console.log(domination_index);
        //console.log(amount_in);
        results.push(Object.values(domination_distr))
        domination_distr[domination_index] = 0;
        return;
    }
    
    if(amount_in > 0){
        var give = 0; 
        while( give <= amount_in){
            amount_r = amount_in -  give;
            //console.log("amount_r", amount_r);
            //console.log("give", give);
            if( (give == 0 && (amount_r % domination[domination_index] == 0)))
            {
                domination_distr[domination_index] = amount_r;
                dominations(results, domination, target, amount_r , domination_distr, domination_index);
                give += domination[domination_index]
                //console.log("1", domination_index);
                
            } 
            else if(domination[domination_index + 1] && give == 0 && 
                ((amount_in % domination[domination_index + 1])% domination[domination_index] ) == 0 )
            {
                    give += domination[domination_index + 1]
                    //console.log("2", domination_index);
                    
            }else if ((domination[domination_index + 1] && 
                give >=  domination[domination_index + 1] &&
                amount_r % domination[domination_index] == 0  ))
                {
                     //console.log("3", domination_index);
                     domination_distr[domination_index] = amount_r;
                     dominations(results, domination, target, give , domination_distr, domination_index + 1);
                     give += domination[domination_index]
                }
                else
                    give += domination[domination_index]
        }
    }
}

/* results = [];
domination_distr = [0, 0 , 0 , 0, 0, 0];
domination = [1, 5, 10, 25, 50, 100]
target  = 100;
amount_in = 100;
domination_index =  0;

dominations(results, domination, target, amount_in, domination_distr, domination_index);
console.log(results); */

function all_dominations_for_n(n, domination){
    
        results = [];
        domination_distr = new Array(domination.length)          
        target  = n;
        amount_in = n;
        domination_index =  0;
        for(var i = 0;  i < domination_distr.length;  i++)
             domination_distr[i] =  0;

        dominations(results, domination, target, amount_in, domination_distr, domination_index);
        for(var entry  in results )
            console.log(results[entry]);
        console.log("cnt:",results.length);
}

domination = [1, 5, 10, 25, 50, 100];
all_dominations_for_n(100, domination)
