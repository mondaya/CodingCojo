// Write your Javascript code.
$(document).ready(function(){
    getMovies();
     $('#search').change(function(){
        $('#error').html("");
        console.log("hello");
        var  term = $("#search").val();   
        console.log(term);  
        if(term.length > 0) {        
            $.get(`movie/${term}`,
                function(result){
                    console.log(result);
                    if(result.failed)
                    {
                        $('#error').html("<h3>term not found</h3>")
                    }
                    else{
                        displayMovie(result)
                    }
                },"json");   
        }                                 

    });   


})


function getMovies(){
    $("#show").text("");
    $.get("/movies", function(result){
        for( movie of result){
            displayMovie(movie);
        }
    })
}


function displayMovie(movie){
    var date  = new Date(movie.releasedAt);
    $("#show").prepend(`
                <p>${movie.title}&nbsp;&nbsp;&nbsp;${movie.rating}&nbsp;&nbsp;&nbsp; ${date.toDateString().slice(3)}</p>
            `);
}