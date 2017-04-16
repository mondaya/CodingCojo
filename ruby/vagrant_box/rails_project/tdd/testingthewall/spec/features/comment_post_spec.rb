require 'rails_helper'
feature "signed user creates a comment" do
  
=begin 
  scenario "successfully creates a new user account" do
    visit new_user_path
    fill_in "user_first_name", with: "shane"
    fill_in "user_last_name", with: "chang"
    fill_in "user_email", with: "schang@codingdojo.com"
    click_button "Create User"
    expect(page).to have_content "User successfully created"
  end
=end

  before(:each) do 
    visit new_user_path
    fill_in "user_user_name", with: "shane"   
    click_button "Sign In"
    expect(page).to have_content "Welcome, shane"
    expect(page).to have_current_path(posts_path) 
    fill_in "post_message", with: "This is my first post since waking up the dead"   
    click_button "Post a Message"
    expect(page).to have_content "This is my first post since waking up the dead"   
  end
  scenario "1.allow user to creates a comment" do
    fill_in "comment_message", with: "This is my first comment since waking up the dead"   
    click_button "Post a Comment"
    expect(page).to have_content "This is my first comment since waking up the dead"   
  end 
 

end