"""
    Part I:

    Given the following list:

    students = [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
    Copy
    Create a program that outputs:

    Michael Jordan
    John Rosales
    Mark Guillen
    KB Tonel
"""

students = [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]

for student in students :
    print student['first_name'], student['last_name']

print
print

"""
    Part II:

    Now, given the following dictionary:

    users = {
     'Students': [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
      ],
     'Instructors': [
         {'first_name' : 'Michael', 'last_name' : 'Choi'},
         {'first_name' : 'Martin', 'last_name' : 'Puryear'}
      ]
     }
    Copy
    Create a program that prints the following format (including number of characters in each combined name):

    Students
    1 - MICHAEL JORDAN - 13
    2 - JOHN ROSALES - 11
    3 - MARK GUILLEN - 11
    4 - KB TONEL - 7
    Instructors
    1 - MICHAEL CHOI - 11
    2 - MARTIN PURYEAR - 13
"""
users = {
     'Students': [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
      ],
     'Instructors': [
         {'first_name' : 'Michael', 'last_name' : 'Choi'},
         {'first_name' : 'Martin', 'last_name' : 'Puryear'}
      ]
     }
for type_of_users,users in dict.items(users) :
    print type_of_users
    for index, person  in enumerate(users):
       first = person['first_name'].upper()
       last = person['last_name'].upper()
       print index+1, "-", first, last, "-", len(first + last) 
