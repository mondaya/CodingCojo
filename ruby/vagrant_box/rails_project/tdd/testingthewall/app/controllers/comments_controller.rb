class CommentsController < ApplicationController
  def create
    @comment = Comment.create(message:params[:comment][:message], 
                              user:User.find(session[:user_id]), 
                              post:Post.find(params[:post_id]))
    if @comment.invalid?       
      flash[:errors]  = @comment.errors.full_messages  
    end
    redirect_to :back
  end
end
