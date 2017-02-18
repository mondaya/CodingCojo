var students = [ 
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
]

function printFirtLastName(objs, decorate = false) {
    for( var obj = 0; obj <  objs.length;  obj++){
        if( !decorate )
            console.log(objs[obj].first_name, objs[obj].last_name);
        else 
        {
            var len = objs[obj].first_name.length + objs[obj].last_name.length;
            console.log((obj + 1), "-", objs[obj].first_name, objs[obj].last_name, "-", len);
        }            
    }
}
printFirtLastName(students);

var users = {
 'Students': [ 
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
  ],
 'Instructors': [
     {first_name : 'Michael', last_name : 'Choi'},
     {first_name : 'Martin', last_name : 'Puryear'}
  ]
 }
 
 for( var userType in users) {
     console.log(userType);
     printFirtLastName(users[userType], true );
 }
 
/* var bod = document.body;
for (var i = 0; i < 10; i ++){
    var p = document.createElement("p");
    var text = document.createTextNode("This has gone through the loop completely: " +i+ " times");
    p.appendChild(text);
    bod.appendChild(p);
} 
var paragraphs = document.getElementsByTagName('p');
console.log(paragraphs);
for (var i = 0; i < paragraphs.length; i ++){
  console.log(paragraphs[i].addEventListener);
  paragraphs[i].addEventListener('click', function(){
    this.style.background='blue';
  });
}
*/
 