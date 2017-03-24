// Write your Javascript code.
$(document).ready(function(){
                
                $('#description textarea').click(function(){               
                    $(this).attr('readonly', false);
                    $(this).siblings().show();                                      

                });              

               $(document).on( "submit","#note", function(){                 
                        
                        console.log("hello");
                        $.post( "update/", $(this).serialize() )
                                .done(function( data ) {
                                     alert( "Data Loaded: " + data.success );                                     
                                }, "json");  
                    $(this).children().last().children().first().attr("readonly", true);
                    $(this).children().last().children().last().hide();
                     //event.preventDefault(); 
                     return true;                                 
                });                               
                
            });