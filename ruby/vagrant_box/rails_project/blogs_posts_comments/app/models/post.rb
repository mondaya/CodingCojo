class Post < ApplicationRecord
    has_many :comments ,  dependent: :destroys
    belongs_to :blog
    belongs_to :user
    validates :title, presence: true, length: {minimum:7}
    validates :content, presence: true
    
end
