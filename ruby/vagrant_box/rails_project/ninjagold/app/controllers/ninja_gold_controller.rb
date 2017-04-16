class NinjaGoldController < ApplicationController
  include NinjaGoldHelper

  def index 
 
    if session[:find_gold_db].nil? 
        session[:find_gold_db] = {score:nil, activities:nil}
        session[:find_gold_db]['score'] = 0
        session[:find_gold_db]['activities'] = Array.new 
    end    
   
    @game =  session[:find_gold_db];   
    return render
  end

  def find_gold 
    building = params[:building]
    srand = Random.new_seed 
    golds = {:farm  => rand(10..20), :cave  => rand(5..10), :house => rand(2..5), :casino => rand(-50..50)}   
    activity = {:type => building, :profit => golds[building.to_sym], :time  => get_current_datetime.strftime("%Y %d %b, %I:%M %p")}   

    session[:find_gold_db]['score'] =  session[:find_gold_db]['score'].to_i + golds[building.to_sym].to_i
    session[:find_gold_db]['activities'] << activity

    return redirect_to controller:'ninja_gold', action:'index'  
  end

  def reset
     session[:find_gold_db]['score'] = 0
     session[:find_gold_db]['activities'] = Array.new 
    return redirect_to controller:'ninja_gold', action:'index'

  end
end
