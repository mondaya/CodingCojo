from __future__ import unicode_literals
from django.db import models
from ..login_reg.models import User

# Create your models here.
class Course(models.Model):
    course_name = models.CharField(max_length=34)
    description = models.TextField()
    users = models.ManyToManyField(User, related_name = 'has_courses')
    created_at =  models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)