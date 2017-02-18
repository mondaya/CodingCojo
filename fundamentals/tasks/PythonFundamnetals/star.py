"""
    Part 1
    Create a function called draw_stars() that takes a list of numbers and prints out *.

    For example:

    x = [4, 6, 1, 3, 5, 7, 25]
    
    Part 2 
    
    Modify the function above. Allow a list containing integers and strings to be passed to the draw_stars() function. When a string is passed, instead of displaying *, display the first letter of the string according to the example below. You may use the .lower() string method for this part.

    For example:

    x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
    Copy
    draw_stars(x) should print the following in the terminal:

    ****
    ttt
    *
    mmmmmmm
    *****
"""

import sys  #print attches \n by default, hence the need sys

# This  function depends on sys imported.
# it will print n time the value followed by end of line

def print_n_times(value, times):
    for x in range(times):
        sys.stdout.write(value)
    sys.stdout.write("\n")
    sys.stdout.flush()

def draw(list):
    
    for item in list :
        if isinstance(item, str) :
            print_n_times(item[0].lower(), len(item))
        else:
            print_n_times("*", item)




draw([4, 6, 1, 3, 5, 7, 25])
print "\n"
draw([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])
