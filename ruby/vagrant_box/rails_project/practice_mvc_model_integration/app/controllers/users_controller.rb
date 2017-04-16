
class UsersController < ApplicationController
  def create
    User.create(first_name:params[:first_name],  last_name:params[:last_name], email_address:params[:email_address], age:params[:age])
    return redirect_to "/users" 
  end

  def new
  end

  def edit
     @user = User.find(params[:id])
  end

  def show
    render json: User.find(params[:id])
  end

  def update
    User.find(params[:id]).update(first_name:params[:first_name],  last_name:params[:last_name], email_address:params[:email_address], age:params[:age])
    #User.create(first_name:params[:first_name],  last_name:params[:last_name], email_address:[:email_address], age:params[:age])
     return redirect_to "/users"
  end

  def destroy
  end

  def index
      render json: User.all
  end

  def total
      render json: User.count
  end

end
