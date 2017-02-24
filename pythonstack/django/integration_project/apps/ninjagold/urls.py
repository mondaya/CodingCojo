from django.conf.urls import url, include
import views

urlpatterns = [
    
    url(r'^$', views.index,name='home'),
    url(r'^process_money/(?P<building>\w+)$',views.find_gold),
    url(r'^reset$',views.reset),
]