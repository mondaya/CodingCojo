require 'rails_helper'


feature 'User Regeistration' do
    context "valid attribute" do
        visit "users/new"
        fill_in'user_name', with: "superstarninja"
        click_button "create_user"

        expect(surredn_path).to eq('messages')
        expect(page)    
    end
end