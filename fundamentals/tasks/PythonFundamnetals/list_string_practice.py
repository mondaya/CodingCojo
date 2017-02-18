str = "If monkeys like bananas, then I must be a monkey!"

"""
    print the position for all instances of the word "monkey". Then create a new string where the word "monkey" is replaced with the word "alligator
"""
sub = 'monkey'
strlen = len(str)
sub_len = len(sub)
i  = 0;
while i < strlen :
    sub_index = str.find(sub, i,strlen)
    print sub_index;
    if sub_index == -1 :
        break;
    else :
        i = (sub_index + sub_len + 1)
new_str = str.replace(sub, 'alligator')
print new_str

x = [2,54,-2,7,12,98]

"""
  Print the min and max values in a list like this one: x = [2,54,-2,7,12,98]. Your code should work for any list.  
"""

def min_max (data):
    
    if len(data) <= 0:
        return        
    min_num = data[0]
    max_num = data[0]
    for num in data :
        if num > max_num :
            max_num = num
        if num < min_num :
            min_num = num
    print "(min,max)->({},{})".format(min_num, max_num)
    
min_max(x)

"""
    Print the first and last values in a list like this one: x = ["hello",2,54,-2,7,12,98,"world"]. Now create a new list containing only the first and last values in the original list.
"""
x = ["hello",2,54,-2,7,12,98,"world"]
def first_last(data) :

    if len(data) <= 0:
        return
    first = data[0]
    last = data[-1]
    print "(first,last)->({},{})".format(first, last)
    new_list = [first, last]
    return new_list
print first_last(x)


"""
    return true in x is negative else false
"""
def neg_num(x):
    return x < 0


"""
    Start with a list like this one: x = [19,2,54,-2,7,12,98,32,10,-3,6]. Sort it, then slice out all of the values that are negative, placing those values in a new list.
    Then add your new list into the original one at position 0. The output should be: [[-3, -2], 2, 6, 7, 10, 12, 19, 32, 54, 98]. This one is tough!
"""

x = [19,2,54,-2,7,12,98,32,10,-3,6]

x.sort();

neg_list = filter(neg_num, x)

for num in  neg_list :
    x.remove(num)
x.insert(0, neg_list)

print x
