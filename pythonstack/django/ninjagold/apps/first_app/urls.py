from django.conf.urls import url, include
import views

urlpatterns = [
    
    url(r'^$', views.index),
    url(r'^find_gold_result$',views.find_gold),
    url(r'^reset$',views.reset),
]