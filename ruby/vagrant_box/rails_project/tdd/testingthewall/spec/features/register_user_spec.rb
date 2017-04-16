require 'rails_helper'
feature "guest user creates an account" do
  
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
  end
  scenario "1.successfully creates a new user account" do
    fill_in "user_user_name", with: "shane"   
    click_button "Sign In"
    expect(page).to have_content "Welcome, shane"
    # We'll be redirecting to the user show page is user succesfully created
    expect(page).to have_current_path(posts_path)    
  end 
 

end