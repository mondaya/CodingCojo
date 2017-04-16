require_relative "mammal"

class Dog < Mammal

    def pet
        @health += 5
        self
    end

    def walk times=1
        unless health < 1*times
            @health -= 1*times
        end
            self

    end

    def run times=1
        unless health < 10*times
            @health -=10*times
        end
            self
    end

  end 


dog = Dog.new

dog.walk(3).run(2).pet.display_health