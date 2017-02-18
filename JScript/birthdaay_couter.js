var daysUntilMyBirthday = 60;

var numDaysLeft = daysUntilMyBirthday;
while(numDaysLeft > 0) {
    
    var simlleyFace = "birthday:(";
    
    if(numDaysLeft < 30 && numDaysLeft > 5)
        simlleyFace = ":)";
    
    if(numDaysLeft <= 5)
        simlleyFace = "BIRTHDAY!!";
    
    if(numDaysLeft == 1) {
        console.log("HAPPY BIRTHDAY!!!!!!" );
        console.log("♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪ღ♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•*");
        console.log("♪ღ♪░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░░♪ღ♪");
        console.log("*•♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•«");      
        break;
    }
    
    numDaysLeft--;
    console.log("You have", numDaysLeft, "days untill my", simlleyFace );
}

