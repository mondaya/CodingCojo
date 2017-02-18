"""
    Create a function called odd_even that counts from 1 to 2000. As your loop executes have your program print the number of that iteration and specify whether it's an odd or even number.
"""
def odd_even() :
    for num in range(1,2001):
        if num % 2 == 1 :
          print "Number is {}.".format(num), "This is odd number"
        else :
          print "Number is {}.".format(num), "This is even number"

"""
    Create a function called 'multiply' that iterates through each value in a list (e.g. a = [2, 4, 10, 16]) and returns a list where each value has been multiplied by 5.
"""

def multiply(data, mul):
    new_list = []
    for num in data :
        new_list.append(num * mul);
    return new_list;
    
#  Verify

odd_even();
print multiply([2, 4, 10, 16], 5);


"""
    Write a function that takes the multiply function call as an argument. Your new function should return the multiplied list as a two-dimensional list. Each internal list should contain as many ones as the number in the original list. Here's an example:
"""

def layered_multiples(arr):
  new_list = []
  for num in arr :
    new_list.append([1 for i in range(0, num)]);
  return new_list
  
#  Verify
x = layered_multiples(multiply([2,4,5],3))
print x
