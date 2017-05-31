$(document).ready(function(){
    //alert("hello world");
    $("img").click(function() {
        $(this).hide();
    });
    
    $("button").click(function() {
        $("img:hidden").show();                
    });
       
});