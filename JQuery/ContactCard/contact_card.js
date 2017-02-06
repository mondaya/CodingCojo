$(document).ready(function(){
    //alert("hello world");      
    
    $(document).on("mousedown", "#cards div", function(){
       var descr =  $(this).data("card").description;
       $(this).html("<p>" + descr + "</p>");
       
    });  

    $(document).on("mouseup", "#cards div", function(){
       
       var firstName = $(this).data("card").first;
       var lastName = $(this).data("card").last;
       $(this).html("<p><b>" + firstName + " " + lastName + 
                                      "</b></p><p>click for description</p>"); 
       
    });     
    $("form").submit(function(){
        //alert("hello world");
        var firstName = $("#f_name").val();
        var lastName = $("#l_name").val(); 
        var description = $("#description").val();        
        $("#cards").append("<div></div>");
        var  user = $("#cards div").last();
        user.append("<p><b>" + firstName + " " + lastName + 
                                      "</b></p><p>click for description</p>");   
        user.data("card", {"description":description, "first":firstName, "last":lastName});                                     
        return false;
    });
    
});