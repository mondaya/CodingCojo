FactoryGirl.define do
  factory :comment do
    message "MyString"
    Post
    User
  end
end
