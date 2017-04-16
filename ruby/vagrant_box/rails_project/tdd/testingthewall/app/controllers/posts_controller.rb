class PostsController < ApplicationController
  def index
    @posts = Post.all
  end

  def create
    puts message:params[:post][:message]
    @post = Post.create(message:params[:post][:message], user:User.find(session[:user_id]) )
    puts "@post valid #{@post.valid?}"
    redirect_to :back
  end
end
