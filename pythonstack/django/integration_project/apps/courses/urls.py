from django.conf.urls import url
import views
urlpatterns = [
    url(r'^$', views.index, name='home'),
    url(r'^show$', views.show, name='show'),
    url(r'^create$', views.create , name='create'),
    url(r'^remove/(?P<book_id>\d+)$', views.remove, name='remove'),
    url(r'^delete/(?P<book_id>\d+)$', views.delete, name='delete'),
    url(r'^users/$', views.create_users, name='create_user'),
    
]
