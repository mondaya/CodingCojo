from django.shortcuts import render, redirect


# Create your views here.

def index(request):
    request.session.clear()
    return render(request, 'first_app/index.html')
def process_survey(request):       
    request.session['user_name'] =  request.POST["user_name"]
    request.session['fav_lang'] =  request.POST["fav_lang"]
    request.session['dojo_location'] =  request.POST["dojo_location"]
    request.session['comment'] =  request.POST["comment"]    
    return redirect('/survey_result')
def survey_result(request):  
    return render(request, 'first_app/result.html')
