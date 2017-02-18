var HOUR = 1;
var MINUTE = 00;
var PERIOD =  "AM";


var minuteHandIs = "";
var amPm = "";
var hour = HOUR;

if( PERIOD === "PM" ){
    amPm = "in the evening";        
}
else{
    amPm ="in the morning";
}

 if( PERIOD === "PM"  && (HOUR % 12) < 3  ){
    amPm = "in the afternoon";        
}

if( PERIOD === "PM"  && (HOUR % 12) > 9 ){
    amPm = "at night";        
}

hour = HOUR;

if( MINUTE < 30 && MINUTE > 0 ){
    //minuteHandIs = "just after";
    minuteHandIs =  MINUTE + " after";
    if( MINUTE === 15 ){
       minuteHandIs = "quater after";
    }
        
}
else  if( MINUTE >= 30 && MINUTE <= 59 ){
    //minuteHandIs = "almost";
    hour = hour%12; + 1;
    
    minuteHandIs = (60- MINUTE) + " to";
    
    if( MINUTE === 30 ){
       hour = HOUR;
       minuteHandIs = "half past";
    }
    
    if( MINUTE === 45 ){
       minuteHandIs = "quater to";
    }   
}
else 
{     
    if( PERIOD === "PM" && hour === 12 ){
        amPm = "noon";        
    }
    else if( PERIOD === "AM" && hour === 12 ){
        amPm ="midnight";
    }
}

console.log( "it's", minuteHandIs, hour , amPm);