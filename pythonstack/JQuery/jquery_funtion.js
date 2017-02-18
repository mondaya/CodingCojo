$(document).on('click', '#slideUpClassBtn', function() {
        $("#slideImg").slideUp(1000, function(){
            $("#slideUpClassBtn").text("Slide Down"); 
            $("#slideUpClassBtn").attr("id", "slideDownClassBtn") 
        });
        
    });
 $(document).on('click', '#fadeInClassBtn', function() {
        $("#slideImg2").fadeIn(1000, function(){
            $("#fadeInClassBtn").text("Fade Out"); 
            $("#fadeInClassBtn").attr("id", "fadeOutClassBtn") 
        });
        
    });
$(document).ready(function(){
    //alert("hello world");
    $("#clickClassBtn").click(function() {
        $("#showClickBtnText").text("Wow what a click. JQ is Awsome!!!!")
        $("#showClickBtnText").css("font-weight", "bold");
    });
    
    $("#hideClassBtn").click(function() {
        //alert("hello world");
        $("#hideText").hide();
        
    });
    
     $("#showClassBtn").click(function() {
        //alert("hello world");
        $("#hideText").show();
        
    });
    
    
    function toggleBtnColor(){   
        console.log($(this).css("background-color"));        
        if( $(this).css("background-color")  ===  "rgb(255, 0, 0)")
            $(this).css("background-color", "green");
        else
           $(this).css("background-color", "red"); 
       $(this).show();
    }
    
    $("#toggleClassBtn").click(function() {
        $(this).toggle(toggleBtnColor);
        
    });
    
    $("#slideDownClassBtn").click(function() {
        $("#slideImg").slideDown(1000, function(){
            $("#slideDownClassBtn").text("Slide Up"); 
            $("#slideDownClassBtn").attr("id", "slideUpClassBtn") 
        });
        
    });
    
    $("#slideToggleClassBtn").click(function() {
        $("#slideImg1").slideToggle(1000);
        
    });
    
     $("#fadeOutClassBtn").click(function() {
        $("#slideImg2").fadeOut(1000, function(){
            $("#fadeOutClassBtn").text("Fade In"); 
            $("#fadeOutClassBtn").attr("id", "fadeInClassBtn") 
        });
        
    });
    
    $("#addClassClassBtn").click(function() {
        $("p").addClass("blue_bk");
        $("p, h2, #showClassBtn").addClass("blue_bk");
        
    });
    
    $("#beforeClassBtn").click(function() {
        $("h2").before("<h1>>></h1>");
        
    });
    
    $("#afterClassBtn").click(function() {
        $("h2").after("<h1><<</h1>");
        
    });
    
     $("#appendClassBtn").click(function() {
        $("#container").append("<h1>I was appended here by the append button</h1>");
        
    });
    
    $("#htmlClassBtn").click(function() {
        var html = $(".functionText").html();
        alert("This is the first :" + html);
        
    });
    
    $("#attrClassBtn").click(function() {
        var attr = $(".functions div p").attr("id");
        alert("This is the first :" + attr);
        
    });
    
    $("#valClassBtn").click(function() {
        var val = $("#textInpArea input").val();
        alert("This is the first :" + val);
        
    });
    
     $("#textClassBtn").click(function() {
        var val = $("#container div").text();
        alert("This is the first :" + val);
        
    });
    
     $("#dataClassBtn").click(function() {
        var val = $("#data").data( "test", { category: "DUI", count: 212 } );
        $( "span:first" ).text( $( "#data" ).data( "test" ).category );
        $( "span:last" ).text( $( "#data" ).data( "test" ).count );
        console.log($("p #showClickBtnText"));
        
    });
    
       
});