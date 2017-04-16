class Wizard < Human
    def initialize
        super
        @health = 50
        @intelligence = 25    
    end 

    def heal 
        @health += 10
        self
    end

    def fireball victim, times=20
        attack victim, times 
        self       
    end   
            
 
end