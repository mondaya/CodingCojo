from __future__ import unicode_literals

from django.db import models 
from ..login_reg.models import User
from django.db.models import When, F, Q,Case,Value,BooleanField


class PostManager(models.Manager):
    def create_post(self, data, user_id):
        errors=[]
        if len(data['post_data']) < 2:
            errors.append('post needs to greater than  charaters')
        if len(errors) > 0 :
            return {'status':False, 'errors':errors}
        else :
            post = self.create(secret=data['post_data'], user=User.objects.get(id=user_id))
            return {'status':True, 'post_id':post.id}
    def is_user_in_post(self, user_id):
  
        posts = self.annotate(
                        num_likes=models.Count('likes')
        ).annotate(
                        is_user_post=Case(
                                                    When(user__id=user_id,then=Value(True)),
                                                    default=Value(False),
                                                    output_field=BooleanField(),
                                         )
         ).order_by('-created_at')[:10]        
        liked_by_user = self.filter(likes__id=user_id).values_list('id', 'likes__id')
        dict_liked_by_user = dict((x, y) for x, y in liked_by_user)
        return (posts,dict_liked_by_user)
            
    def popular_post(self, user_id):
        
        posts = self.annotate(
                        num_likes=models.Count('likes')
        ).annotate(
                        is_user_post=Case(
                                                    When(user__id=user_id,then=Value(True)),
                                                    default=Value(False),
                                                    output_field=BooleanField(),
                                         )
        ).all().order_by('-num_likes')
        liked_by_user = self.filter(likes__id=user_id).values_list('id', 'likes__id')
        dict_liked_by_user = dict((x, y) for x, y in liked_by_user)
        return (posts,dict_liked_by_user)        
        
    
    def like_post(self, user_id, post_id):        
        post = self.get(id=post_id)
        user = User.objects.get(id=user_id);
        post.likes.add(user) 
        print '*'*80
        print self.all().count()        
        return
    def delete_post(self, user_id, post_id):        
        post = self.get(id=post_id)
        post.delete()      
        return

# Create your models here.
class Post(models.Model):
    secret=models.TextField()
    user=models.ForeignKey(User,  related_name="user_posted")
    likes=models.ManyToManyField(User, related_name="user_likes")
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)
    objects=PostManager()
    