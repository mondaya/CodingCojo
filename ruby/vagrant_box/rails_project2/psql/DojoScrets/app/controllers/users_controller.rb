class UsersController < ApplicationController
  
   skip_before_action :require_login, only: [:new, :create]

  def new
      
  end

  def show
      #return redirect_to new_session_path unless current_user
      if current_user.id === params[:id].to_i
        @user = User.find(current_user.id)
        return render
      end
      return redirect_to  new_session_path

  end 

  def create

    @user = User.create(name:params[:Name], email:params[:Email],  password:params[:Password], password_confirmation:params[:Password_Confirmation])

    if @user.invalid?
      flash[:errors] = @user.errors.full_messages
      return redirect_to action: "new"
    end

    return redirect_to  new_session_path


  end

  def edit
      # return redirect_to new_session_path unless current_user 
  end 

  def update
         
      if current_user  && (current_user.id  == params[:id].to_i )
        @user = User.find(current_user.id)
        @user.name = params[:Name]
        @user.email = params[:Email]

        if @user.save 
          return redirect_to user_path(current_user)
        else
          flash[:errors] = @user.errors.full_messages
          return redirect_to  :back
        end
      end
      flash[:errors] = ["Invalid User"]
      session[:user_id] = nil
      return redirect_to action: "new"
  end

  def destroy

      if current_user  && current_user.id  == params[:id].to_i 
        @user = User.find(current_user.id)   
        @user.delete          
      end
      session[:user_id] = nil
      return redirect_to action: "new"
  end
end
