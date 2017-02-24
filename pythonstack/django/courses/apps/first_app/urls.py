from django.conf.urls import url
import views
urlpatterns = [
    url(r'^$', views.index),
    url(r'^create$', views.create),
    url(r'^remove/(?P<book_id>\d+)$', views.remove),
    url(r'^delete/(?P<book_id>\d+)$', views.delete),
    
]
