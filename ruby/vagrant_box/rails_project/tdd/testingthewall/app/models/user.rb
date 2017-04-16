class User < ActiveRecord::Base
    has_many :post
    has_many :comment
    validates :user_name, presence:true
    validates :user_name, uniqueness:true, unless: Proc.new { |a| a.user_name.blank? }
end
