$(document).ready(function(){
    //alert("hello world");      
        
    $("form").submit(function(){
        //alert("hello world");
        var firstName = $("#f_name").val();
        var lastName = $("#l_name").val(); 
        var eMail = $("#e_mail").val();
        var contactNo = $("#contact_no").val();        
        $("table").append("<tr></tr>");
        $("table tr").last().append("<td>" + firstName + "</td>");
        $("table tr").last().append("<td>" + lastName + "</td>");
        $("table tr").last().append("<td>" + eMail + "</td>");
        $("table tr").last().append("<td>" + contactNo + "</td>");            
        return false;
    });
    
});