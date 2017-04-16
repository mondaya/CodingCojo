class User < ActiveRecord::Base
     validates :first_name, :presence => true
     validates :last_name, :presence => true
     validates :email, :presence => true, :uniqueness => { case_sensitive: false }
     validates :email, format: { with: /\A[\w+\-.]+@[a-z\d\-]+(\.[a-z\d\-]+)*\.[a-z]+\z/i,
            message: "only allows A-Za-z@" }
end
