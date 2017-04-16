class DojoSurveyController < ApplicationController
  def index
    session[:veiws] ||= 0 
  end

  def process_survey

    in_survey =  params[:survey]
    survey =  DojoSurvey.new()
    survey.user_name  = in_survey[:user_name]
    survey.dojo_location = in_survey[:dojo_location]
    survey.fav_lang = in_survey[:fav_lang]
    survey.comment = in_survey[:comment]  
   
   
    if survey.valid?  
      session[:veiws] = session[:veiws] + 1
      flash[:success] = "You submit the form successfully. By the way this form has been submitted #{session[:veiws]} times" 
      session[:survey]=  survey
      return redirect_to controller:'dojo_survey', action:'show'
    end
    @errors = survey.errors.full_messages
    return render 'index'
  end

  def show
    @survey=session[:survey]
  end
end
