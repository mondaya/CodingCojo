require_relative "mammal"
class Lion  < Mammal

    def initialize
        @health =  170
    end
    
    def fly times=1
        unless health < 10*times
            @health -=10*times
        end
        self
    end

     def attack_town times=1

        unless health < 50*times
            @health -=50*times
        end
        self
    end

    def eat_humans times=1       
      @health += 20*times     
      self
    end

    def display_health
      puts "This is a lion." 
      super
      self 
    end
end



lion =  Lion.new

lion.attack_town(3).eat_humans(2).fly(2).display_health