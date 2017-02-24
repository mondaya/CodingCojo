from django.conf.urls import url
import views
urlpatterns = [
    url(r'^$', views.index),
    url(r'^resgister$', views.registration),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout),
    url(r'^success$', views.success),
    
    
]
