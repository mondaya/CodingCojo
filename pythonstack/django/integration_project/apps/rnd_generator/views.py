from django.shortcuts import render, redirect
import random
import string

# Create your views here.
def index(request):
    return render(request, 'first_app/index.html')
def generateRndKey(request):
    
    if  'count' in request.session:
      request.session['count'] += 1
    else :
      request.session['count'] = 1
    rndkey =  "".join(random.choice(string.ascii_uppercase + string.digits) for _ in range(14))  
    request.session['keyword'] = rndkey
    print  rndkey ,request.session['keyword']
    return redirect('rndgen:home')
