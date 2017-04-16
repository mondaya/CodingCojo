class DojoSurvey < ActiveRecord::Base
    validates :user_name, presence: true, length:{minimum:5} 
    validates :comment, presence: true, length:{minimum:10}
end
