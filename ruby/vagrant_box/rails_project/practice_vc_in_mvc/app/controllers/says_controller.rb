class SaysController < ApplicationController
  def sayTo

     if params[:name] == 'micheal'
       return redirect_to "/say/hello/joe"       
     end
     render text: "Saying Hello #{params[:name].capitalize}!" 
  end

  def index
      return render text: "What do you want me to say???"  if params[:what].nil?
      render text: "Saying Hello #{params[:what].capitalize}!" 
  end
end
