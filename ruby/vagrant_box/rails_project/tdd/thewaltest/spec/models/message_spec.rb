require 'rails_helper'

RSpec.describe Message, type: :model do
 context "with valid attribures do" do
   it "should save message with long enough message" do
    expect(build(:message)).to be_valid 
   end
  end

  context "with invalid attribures" do
    it "should not allow save with too short message" do 
      expect(build(:message)).to be_invalid
    end
  end

end
