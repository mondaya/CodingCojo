class Blog < ApplicationRecord
    has_many :posts, dependent: :destroy
    has_many :owners ,dependent: :destroy
    has_many :users, through: :owners

    validates :name,:description, presence: true
end
