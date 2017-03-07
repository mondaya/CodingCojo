from __future__ import unicode_literals
from django.db import models


class UserManager(models.Manager):
    
        def registration(request):
            error = []
            if request.method == "POST":
                if len(request.POST['course_name']) < 1:
                    error.append("course name is empty")
                if len(request.POST['description']) < 1:
                    error.append("description name is empty")
                
                if len(error) == 0:
                    Course.objects.create(course_name=request.POST['course_name'], description=request.POST['description'])
            return redirect("/")
            
        def login(request):
            context = {
                'course': "",
            }
            request.session['user'] = 'Monday'
            return redirect('/success')

# Create your models here.
class User(models.Model):
    first_name = models.CharField(max_length=34)
    last_name = models.CharField(max_length=34)
    email = models.EmailField(max_length=100)
    password = models.CharField(max_length=256)
    created_at =  models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    userManger = UserManager()