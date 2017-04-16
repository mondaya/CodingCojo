class User < ApplicationRecord
    has_many :posts
    has_many :comments
    has_many :owners
    has_many :blogs, through: :owners
end
