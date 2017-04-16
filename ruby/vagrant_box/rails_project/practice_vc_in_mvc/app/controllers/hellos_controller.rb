class HellosController < ApplicationController
  def times
       if session[:times].nil? 
             session[:times] = 0
       end
       session[:times]  = session[:times]  + 1
       render text: "You visited this url #{session[:times]} times"

  end

   def restart     
       session[:times]  =  nil
       render text: 'Destroyed the session!'

  end

  def index
      render text: 'Hello CodingDojo!'
  end
end
