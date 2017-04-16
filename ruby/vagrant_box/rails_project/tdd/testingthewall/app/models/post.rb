class Post < ActiveRecord::Base
  belongs_to :user
  has_many :comments
  validates :message,  presence: true,  length:{minimum:10}
end
