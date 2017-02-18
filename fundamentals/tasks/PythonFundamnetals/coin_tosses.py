#import
import random
"""
    You're going to create a program that simulates tossing a coin 5,000 times. Your program should display how many times the head/tail appears.

    Sample output should be like the following:

    Starting the program...
    Attempt #1: Throwing a coin... It's a head! ... Got 1 head(s) so far and 0 tail(s) so far
    Attempt #2: Throwing a coin... It's a head! ... Got 2 head(s) so far and 0 tail(s) so far
    Attempt #3: Throwing a coin... It's a tail! ... Got 2 head(s) so far and 1 tail(s) so far
    Attempt #4: Throwing a coin... It's a head! ... Got 3 head(s) so far and 1 tail(s) so far
    ...
    Attempt #5000: Throwing a coin... It's a head! ... Got 2412 head(s) so far and 2588 tail(s) so far
    Ending the program, thank you!
"""

def coin_tosses():
    total_heads = 0;
    total_tails = 0;
    print "Starting the program..."
    for toss in range(0,5000) :
        if round(random.random()) == 1 :
            face = "head"
            total_heads += 1
        else :
            face = "tail"
            total_tails += 1
        
        print "Attempt #{}: Throwing a coin... It's a {}! ... Got {} head(s) so far and {} tail(s) so far".format(toss, face, total_heads, total_tails);  
    print "Ending the program, thank you!"

coin_tosses()