class Project

    attr_accessor:name, :description, :tasks,:owner
   

    def initialize name=nil, despcription=nil
        @name = name
        @description = despcription
        @owner = "no owner"
        @tasks = []
    end  

    def elevator_pitch
        "#{@name}, #{@description}"       
    end

    def tasks
        @tasks
    end 

    
    def add_tasks task
        @tasks << task
    end

    def print_tasks

         @tasks.each {|task| print task}
        
    end


    
end



