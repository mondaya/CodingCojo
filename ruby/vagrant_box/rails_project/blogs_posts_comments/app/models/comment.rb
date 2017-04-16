class Comment < ApplicationRecord
  belongs_to :user
  belongs_to :post
  validates :content, presence: true, length:{minimum:15}
  validates :user, presence: true
end
