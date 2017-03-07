from django.conf.urls import url
import views


urlpatterns = [ 
    url(r'^$', views.index, name='home'),
    url(r'^posts$', views.post, name='posts'),
    url(r'^posts/popular$', views.popular, name='popular'),
    url(r'^posts/like/(?P<post_id>\d+)$', views.like_post, name='like_post'),
    url(r'^posts/delete/(?P<post_id>\d+)$', views.delete_post, name='delete_post'),
    
    
]