class UsersController < ApplicationController
  def new
    session.delete('user_id')
    session.delete('user_name')
  end

  def create
    name = params[:user][:user_name];
    @user = User.create(user_name: name)
    
    if @user.invalid? && @user.user_name.empty?  
       puts 'Errors', @user.invalid?,   @user.user_name.empty? , @user.errors[:user_name]     
       flash[:errors]  = @user.errors.full_messages
       flash[:errors]  = @user.errors.full_messages 
       return redirect_to :back                         
    end

    session[:user_name] =  name      
    session[:user_id] =  User.find_by(user_name: name).id 
    puts  "session[:user_id] : #{session[:user_id]}"        
   return redirect_to "/posts"
  end
end
