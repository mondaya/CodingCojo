$(document).ready(function() {
    // console.log("hello!")
    $(".connect").click(function() {
        // console.log("asdfadsfnadfijadsfdas")
        var followerId = $(this).attr("userId");
        var aObj = $(this)
        $.post("connect/" + followerId, function(data) {
            if (data.success) {
                // console.log(aObj)
                aObj.parent().html("<p>Pending<p>")
            }
        }, "json");
    })
   
});