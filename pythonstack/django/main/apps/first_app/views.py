# Create your views here.
from django.shortcuts import render, HttpResponse



# Create your views here.
def index(request):
    print "*"*8 + "Hello, I am your first request!" + "*"*8
    return render(request, "first_app/index.html")