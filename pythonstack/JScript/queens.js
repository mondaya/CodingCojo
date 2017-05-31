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

//domination = [1, 5, 10, 25, 50, 100];
//all_dominations_for_n(100, domination)

function sumN(arr, target, loop){
    console.log(arr);
    console.log(target);
    console.log(loop);
    
    if(target == 0){
        return true;
    }
    if(arr.length == 0)
        return false;
    var intElement = arr.pop();
    return (sumN(arr.slice(0), target - intElement, "left") || sumN(arr.slice(0), target,  "right"))
}

arrN = [3,1,2];

console.log(sumN(arrN, 5, "root"));


function subsets(array,  results){
    
    if(!results){
        results  = [];
        results.push([]);
    }
    
    if(array.length < 1 ){
        return;
    }
    
    subsets(array.slice(0,array.length - 1), results)
    var val = array[array.length - 1];
    var subsets_partial = [];
    subsets_partial.push(val);
    for( var subset = 1; subset < results.length; subset++){
        var tempArr = [];
        for(var position = 0; position <= results[subset];  position++){
            subsets_partial.push(tempArr.concat(results.slice(0,position), val, array.slice(position, results.length)))
        }
    
    }
    results.push(subsets_partial);
    
    console.log(results);
    
    
    
}
  

// array =[1]  

function isIcreasing(arr) {
  var count = 0;
  if (arr.length <= 1) {
    return true;
  }
  // loop through array
  for (var i = 1; i < arr.length; i++) {
    // check if index is greater than one before it
    if (arr[i] > arr[i - 1]) {
      // if it is, continue with for loop
      continue
      // else, increment count
    } else {
      count++;
      // if the index ahead exists, we need to check if it is greater than the index before, and the index we’re at.
      if (arr[i+1]) {
        // if it is... continue with for loop
        if (arr[i+1] > arr[i-1] && arr[i+1] > arr[i]) {
          continue
        // else, return false right away, count is greater than 1
        } else {
          return false
        }
      }
    }
    // we check each iteration if count > 1, then return false right away
    if (count > 1) {
      return false
    }
  }
  // if successfuly get through the entire array and count is not > 1, then return true
  return true
}


/* -- write your code in PostgreSQL 9.4

WITH  gt_three_account AS (

   WITH  recipient_with_gt_three_accounts AS (
   
   SELECT  t.* , ROW_NUMBER() OVER (ORDER BY t.*) AS id FROM transfers t JOIN 
    (SELECT recipient  from transfers GROUP BY recipient
    HAVING (SUM(amount) >= 1024 AND COUNT(amount)  > 3 ) ORDER BY recipient) q ON t.recipient = q.recipient
)  
   SELECT distinct a.recipient from recipient_with_gt_three_accounts a, recipient_with_gt_three_accounts b, recipient_with_gt_three_accounts c 
        WHERE a.recipient = b.recipient AND 
        a.recipient = c.recipient AND 
        a.id != c.id AND
        a.id != b.id AND 
        b.id != c.id AND 
        (a.amount +  b.amount + c.amount) >= 1024   
)

SELECT * FROM
    (SELECT q.recipient FROM 
        (SELECT recipient, SUM(amount) AS amount, COUNT(amount) AS count from transfers GROUP BY recipient   
            HAVING (SUM(amount) >= 1024 AND COUNT(amount) <= 3 )) q
            
         UNION ALL 
         
        SELECT * from gt_three_account
    ) f
ORDER BY f.recipient; */



/*



/*
Q) What a BT and a BST is? Difference?

Q)
Class Node { 
    int value; 
    Node left; 
    Node right; 
    boolean isDetach; 
} 

You have a BT and is detach property set to True. Parse the tree and return all the detachable nodes from the tree. 


                                        50
                        30*                             80
                15              45*             65              90*
            5       20      35      48      57      70*     85      100
            
public List<Node> detachNodesFromTree(Node root); 

O/P:
1) Node 90 - {90, 85, 100}
2) Node 70
3) Node 45 - {45, 35, 48}
4) Node 30 - {30, 15, 5, 20}
** 5) Node 50 - {All the remaining nodes - 50, 80, 65, 57}







public List<Node> detachNodesFromTree(Node root) {
    
    List<Node> detatch_list = new List<Node>();
    Stack<Node>stack =  new Stack<Node>stack();
    
    do_detachNodesFromTree(stack,  root);
    foreach( Node node in stack ){
        detatch_list.Add(Node);
    }
    return  detatch_list; 
}
    
private do_detachNodesFromTree(Stack<Node>stack ,  Node root){
    
    if (root == null)
        return;
   
    if(root.isDetached){
     detatch_list.Push(root);
    }
    
    detachNodesFromTree(root.left);
  
    
    if (root.left !=  null && root.left.isDetached){
       root.left = null;
    }
    detachNodesFromTree(root.right);
    
    if (root.right !=  null && root.right.isDetached){
       root.right = null;
    }

    
    return; 
    
}


Your unlock request is in review now. Please allow two business days to process it.

We’ll send you an email message soon with the status of your request, or check it yourself on the Device Unlock Status Portal .

Remember that your request number is NUL922094545871 . Please keep this information for future reference.

e’re reviewing your unlock request now. Please allow two business days for processing.

We’ll email you soon with a decision on your request.

IMEI Number 013331007632031Request Date/Time 05-16-2017 15:26:22 PMRequest Number NUL922094545871Current Status In Progress
*/