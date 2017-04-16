class UsersController < ApplicationController
  def new
  end

  def create
     @user = User.new(params.require(:user).permit(:first_name, :last_name, :email))
    if @user.save
      flash[:notice] = ["Welcome, #{@user.first_name}"]
      redirect_to user_path(@user)
    else
      #errors we need to code later 
      flash[:user] = @user        
      flash[:errors]  = @user.errors.full_messages       
      return redirect_to new_user_path
    end
  end

  def show

  end
end


