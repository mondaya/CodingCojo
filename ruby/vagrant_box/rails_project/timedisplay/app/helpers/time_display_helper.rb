module TimeDisplayHelper
    
    def get_current_datetime()
         zone = ActiveSupport::TimeZone.new("Pacific Time (US & Canada)")
         return Time.now.in_time_zone(zone)
    end
end
