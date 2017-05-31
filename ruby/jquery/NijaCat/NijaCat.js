$(document).ready(function(){
    //alert("hello world");
    $('img').click(function() {
      var prevImage = $(this).attr('src');
      $(this).attr('src', $(this).attr('data-alt-src'));      
      $(this).attr('data-alt-src', prevImage);
    });
       
});