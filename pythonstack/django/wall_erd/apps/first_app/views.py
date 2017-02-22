from django.shortcuts import render

from .models import User

# Create your views here.
def index(request):
    User.objects.create(first_name="Mike", last_name="Hannon")
    users = User.objects.all()
    print(users)
    return render(request, 'first_app/index.html') 