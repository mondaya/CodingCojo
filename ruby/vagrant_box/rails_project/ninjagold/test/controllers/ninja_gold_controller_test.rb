require 'test_helper'

class NinjaGoldControllerTest < ActionController::TestCase
  test "should get index" do
    get :index
    assert_response :success
  end

  test "should get find_gold" do
    get :find_gold
    assert_response :success
  end

  test "should get reset" do
    get :reset
    assert_response :success
  end

end
