class Ninja < Human

    def initialize
        super
        @health = 175
         
    end 

    def heal 
        @health += 10
        self
    end

    def steal victim, times=10
        attack victim, times
        @health += 10
        self
    end 

     def get_away times=15
        unless health < 15*times
            @health -= 15*times
        end
        self
    end 
            
  

end