from django.shortcuts import render, HttpResponse
import time
# Create your views here.
def index(request):
    date_time =  time.localtime();
    context = {
    "date":time.strftime("%b %d, %Y", date_time),
    "time":time.strftime("%I:%M %p", date_time)
    }
    return render(request,'timedisplay/index.html', context)