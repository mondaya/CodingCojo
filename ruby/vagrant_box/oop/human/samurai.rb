class Sumurai
    @@count_sumurai
    
 def initialize
        super
        @health = 200     
        @count_sumurai += 1 
    end 

    def heal 
        @health += 10
        self
    end

    def death_blow victim
        attack victim, victim.health 
        self       
    end 

    def meditate
        @health = 200
        self
    end 
    
    def how_many
        @count_sumurai 
    
    end 

end