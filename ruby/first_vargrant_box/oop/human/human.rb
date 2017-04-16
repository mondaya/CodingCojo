class Human
    attr_accessor:strength,:intelligence,:stealth,:health

    def initialize 
        @strength = 3
        @stealth = 3
        @intelligence = 3
        @health = 100
    end

    def attack victim, times=10

        if victim.class.ancestors.include?  Human
            unless victim.health < 1*times
                victim.health -=1*times
            end  
            return true      
        end
        return false
            
    end
end


h = Human.new
h2 = Human.new
puts h.attack(h2)
puts h.attack("Not a Human")
puts h2.health