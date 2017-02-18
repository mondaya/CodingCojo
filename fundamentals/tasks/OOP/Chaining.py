"""
    far, you have learned how to create objects and use methods within that object. Looking back at the Bike example, you probably had codes that looked like this:

    bike1.ride()
    bike1.ride()
    bike1.ride()
    bike1.reverse()
    bike1.displayInfo()
    Copy
    What if you want to chain methods and have your codes produce the same output but with the following code?

    bike1.ride().ride().ride().reverse().displayInfo()
    Copy
    You probably saw this method of chaining when you did jQuery and when you chained different methods. You could also chain methods in Python by having the method return its own instance! 

    For example if  bike1.ride() returned its own instance (bike1) then you could chain another method to bike1.ride(), doing something like bike1.ride().reverse() or bike1.ride().displayInfo(); If the reverse method or the displayInfo() method also returned its own instance then you could keep chaining! 

    The way you have Python return its own instance is to do something like this

    class Bike(object):
      def ride(self):
        // your code goes here...
        return self
    Copy
    "return self"  returns its own instance allowing you to chain methods after calling that method. Now that you learned this, see if you can go back to the Bike assignment and change it so that it would allow chaining of methods!

    The practice of having OOP return its own instance is pretty common and this can be done with other languages (JavaScript, Ruby, PHP, C++, Java) as well.  Note that in some languages, you do not  return self, rather you return this.
"""

class Bike():

    def __init__(self,price,max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
        
    def displayInfo(self):
        print 'Price is: $' + str(self.price)
        print 'Max speed: ' + str(self.max_speed) + 'mph'
        print 'Total miles: ' + str(self.miles) + ' miles'
        return self
        
    def ride(self):
        print "Riding"
        self.miles += 10
        return self
        
    def reverse(self):
        print "Reversing"
        if self.miles >= 5:
            self.miles -= 5
        return self

        
bike1 = Bike(200,"25mph")
bike2 = Bike(400,"30mph")
bike3 = Bike(100,"10mph")

bike1.ride().ride().ride().reverse().displayInfo()
print "*"*50
bike2.ride().ride().reverse().reverse().displayInfo()
print "*"*50
bike3.reverse().reverse().reverse().displayInfo()


#  To prevent negative distance, update reverse to check for negative distance and reset the miles to zero
