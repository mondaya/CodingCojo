class User < ActiveRecord::Base
=begin 
     #it requires the presence of the all four fields.
     #it requires the age to be numeric. it requires the first_name and the last_name to be at least 2 characters each.
     #it requires the age to be at least 10 and below 150
     #(look into http://apidock.com/rails/ActiveModel/Validations/HelperMethods/validates_numericality_of for some help)

     EMAIL_REGEX = /\A([^@\s]+)@((?:[-a-z0-9]+\.)+[a-z]+)\z/i
    validates :first_name, :last_name, presence: true, length: {minimum: 2} 
    validates :email_address, presence: true, uniqueness: { case_sensitive: false }, format: { with: EMAIL_REGEX } 
    validates :age, presence: true, numericality: {greater_than_or_equal_to: 10, less_than_or_equal_to: 150}
=end
  EMAIL_REGEX = /\A([^@\s]+)@((?:[-a-z0-9]+\.)+[a-z]+)\z/i
  validates :first_name, :last_name, presence: true, length: {minimum: 2} 
  validates :email_address, presence: true, uniqueness: { case_sensitive: false }, format: { with: EMAIL_REGEX } 
  validates :age, presence: true, numericality: {greater_than_or_equal_to: 10, less_than_or_equal_to: 150}
    
end
