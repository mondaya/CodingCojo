from django.shortcuts import render

# Create your views here.
def index(request):
    return render(request,  "vimmyMVC/index.html")
    
def show(request):
    return render(request, "vimmyMVC/show_users.html")
