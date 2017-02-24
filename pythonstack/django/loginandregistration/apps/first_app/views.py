from django.shortcuts import render, redirect 
from .models import User

# Create your views here.
def index(request):
    context = {
        'courses': '',
    }
    return render(request, 'first_app/index.html', context )

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

def logout(request):

    if request.method == "POST":
        if 'user' in request.session:
           request.session.pop('user')
        
    return redirect("/" )
    
def success(request):
    if 'user' in request.session: 
        context = {
            'first_name': request.session['user'],
            'status': 'logged in',
        }
        return render(request, 'first_app/success.html', context )
    else :
        return redirect("/" )