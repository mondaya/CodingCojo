# import
import random

"""
    Write a function that generates ten scores between 60 and 100. Each time a score is generated, your function should display what the grade is for a particular score. Here is the grade table:

    Score: 60 - 69; Grade - D
    Score: 70 - 79; Grade - C
    Score: 80 - 89; Grade - B
    Score: 90 - 100; Grade - A
    The result should be like this...

    Scores and Grades
    Score: 87; Your grade is B
    Score: 67; Your grade is D
    Score: 95; Your grade is A
    Score: 100; Your grade is A
    Score: 75; Your grade is C
    Score: 90; Your grade is A
    Score: 89; Your grade is B
    Score: 72; Your grade is C
    Score: 60; Your grade is D
    Score: 98; Your grade is A
    End of the program. Bye!
"""
MIN_SCORE = 60
MAX_SCORE = 100
def score_grades() :
    print "Scores and Grades"
    for index in range(0, 10) :
        grade =  int((random.random())*((MAX_SCORE - MIN_SCORE) + 1) + 60)
        letter_grade = 'D'
        if grade >= 70 and grade <= 79 :
            letter_grade = 'C'
        elif grade >= 80 and grade <= 89:
            letter_grade = 'B'
        elif grade >= 90 and grade <= 100:
            letter_grade = 'A'
            
        print "Score:{};".format(grade), "Your grade is", letter_grade
    print "End of the program. Bye!"
        
score_grades()
    
