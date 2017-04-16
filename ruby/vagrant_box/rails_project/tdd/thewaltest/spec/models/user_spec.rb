require 'rails_helper'

RSpec.describe User, type: :model do
  context "valid attributes" do
    it "should allow for user creation" do  
      expect(build(:user)).to be_valid
    end
  end

context "with invalid attreibutes" do
  it "should not allow for user creation with empty username" do
    expect(build(:user)).to be_valid
  end 

  it "should not allow" do
    expect(build(:user)).to be_valid  
  end
end



end
