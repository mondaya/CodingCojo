from django.shortcuts import render, redirect
from .models import Course

# Create your views here.
def index(request):
    context = {
        'courses': Course.objects.all(),
    }
    return render(request, 'first_app/index.html', context )

def create(request):
    error = []
    if request.method == "POST":
        if len(request.POST['course_name']) < 1:
            error.append("course name is empty")
        if len(request.POST['description']) < 1:
            error.append("description name is empty")
        
        if len(error) == 0:
            Course.objects.create(course_name=request.POST['course_name'], description=request.POST['description'])
    return redirect("/")
def remove(request, book_id):
    context = {
        'course': Course.objects.get(id = book_id),
    }
    return render(request, 'first_app/delete.html', context )

def delete(request, book_id):
    if request.method == "POST":
        course =  Course.objects.get(id=book_id)
        course.delete()
    return redirect("/" )