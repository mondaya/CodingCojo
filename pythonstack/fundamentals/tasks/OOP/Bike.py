"""
    Create a new class called  Bike with the following properties/attributes:

    price
    max_speed
    miles
    Create 3 instances of the Bike class.

    Use the __init__() function to specify the price and max_speed of each instance (e.g. bike1 = Bike(200, "25mph"); In the __init__() also write the code so that the initial miles is set to be 0 whenever a new instance is created.

    Add the following functions to this class:

    displayInfo() - have this method display the bike's price, maximum speed, and the total miles.
    ride() - have it display "Riding" on the screen and increase the total miles ridden by 10
    reverse() - have it display "Reversing" on the screen and decrease the total miles ridden by 5...
    Have the first instance ride three times, reverse once and have it displayInfo(). Have the second instance ride twice, reverse twice and have it displayInfo(). Have the third instance reverse three times and displayInfo().

    What would you do to prevent the instance from having negative miles?
"""

class Bike():

    def __init__(self,price,max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
        
    def displayInfo(self):
        print self.price, self.max_speed, self.miles
        
    def ride(self):
        print "Riding"
        self.miles += 10
        
    def reverse(self):
        print "Reversing"
        if self.miles >= 5:
            self.miles -= 5

        
bike1 = Bike(200,"25mph")
bike2 = Bike(400,"30mph")
bike3 = Bike(100,"10mph")

bike1.ride()
bike1.ride()
bike1.ride()
bike1.reverse()
bike1.displayInfo()

bike2.ride()
bike2.ride()
bike2.reverse()
bike2.reverse()
bike2.displayInfo()

bike3.reverse()
bike3.reverse()
bike3.reverse()
bike3.displayInfo()

#  To prevent negative distance, update reverse to check for negative distance and reset the miles to zero
