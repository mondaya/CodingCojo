from django.conf.urls import url# Notice we added include
from . import views

#Now from within your newly created apps/first_app/urls.py file...
print "I will be your future routes; HTTP requests will be captured by me."


# def index(request):
    # print "8"*100
    # print "8"*100
    # print "bannanpeel"
    # print "8"*100
    # print "8"*100
    
urlpatterns = [
    url(r'^$', views.index), # And now we use include to pull in our first_app.urls
]





    
   