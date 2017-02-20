from django.conf.urls import url, include
import views

urlpatterns = [
    
    url(r'^$', views.index),
    url(r'^process_money/(?P<building>\w+)$',views.find_gold),
    url(r'^reset$',views.reset),
]