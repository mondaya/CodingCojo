class TimeDisplayController < ApplicationController
  include  TimeDisplayHelper
  def index
      @CurrentTime =  get_current_datetime()
  end
end
