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
    fill_in "user_first_name", with: "shane"
    fill_in "user_last_name", with: "chang"
    fill_in "user_email", with: "schang@codingdojo.com"
    click_button "Create User"
    expect(page).to have_content "Welcome, shane"
    # We'll be redirecting to the user show page is user succesfully created
    expect(page).to have_current_path(user_path(User.last))    
  end
  scenario "2.unsuccessfully creates a new user account" do 
    click_button "Create User"
    expect(current_path).to eq(new_user_path)
  end
  scenario "3.doesn't fill out first name field" do 
    fill_in "user_last_name", with: "shane"
    fill_in "user_email", with: "schang@codingdojo.com"
    click_button "Create User"
    expect(page).to have_content "First name can't be blank"
  end
  scenario "4.doesn't fill out last name field" do 
    fill_in "user_first_name", with: "shane"
    fill_in "user_email", with: "schang@codingdojo.com"
    click_button "Create User"
    expect(page).to have_content "Last name can't be blank"
  end
  scenario "5.doesn't fill out email field" do 
    fill_in "user_last_name", with: "shane"
    fill_in "user_first_name", with: "chang"
    click_button "Create User"
    expect(page).to have_content "Email can't be blank"
  end

end