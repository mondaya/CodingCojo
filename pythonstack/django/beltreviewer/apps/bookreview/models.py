from __future__ import unicode_literals

from django.db import models

# Create your models here.

class Author(models.Model):
    name=models.CharField(max_length=100)
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)
    
class Book(models.Model):
    name=models.CharFeild(max_length=100)
    author=models.ForeginKey(Author, related_name='wrote_book')
    reviewed_by =models.ManyToMany(User, through='Review')    
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)

    
class Review(models.Model):
    content=models.TextFeild()
    rating=models.DecimalFeild() 
    user=models.ForeginKey(User, related_name='reviewed_book')     
    book=models.ForeginKey(Book, related_name='book_reviews')
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)