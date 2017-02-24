from django.shortcuts import render, redirect
from .models import Course
from ..login_reg.models import User

# Create your views here.
def index(request):
    context = {
            'first_name': request.session['user'],
            'status': request.session['user_status'],
            'users':User.userManager.all(),
            'courses':Course.objects.all(),
        }
    return render(request, 'courses/index.html', context )

def show(request):
    context = {
            'courses':Course.objects.all()
        }
    return render(request, 'courses/add.html', context )

def create(request):
    error = []
    if request.method == "POST":
        if len(request.POST['course_name']) < 1:
            error.append("course name is empty")
        if len(request.POST['description']) < 1:
            error.append("description name is empty")
        
        if len(error) == 0:
            Course.objects.create(course_name=request.POST['course_name'], description=request.POST['description'])
    return redirect('courses:home')
    
def remove(request, book_id):
    context = {
        'course': Course.objects.get(id = book_id),
    }
    return render(request, 'courses/delete.html', context )

def delete(request, book_id):
    if request.method == "POST":
        course =  Course.objects.get(id=book_id)
        course.delete()
    return redirect('courses:home' )

def create_users(request):
    if request.method == "POST":
        data = request.POST
        course =  Course.objects.get(id=data['course_id'])  
        user =  User.userManager.get(id=data['user_id']) 
        course.users.add(user)        
    return redirect('home:success' )