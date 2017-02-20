from django.shortcuts import render,  redirect
import random
import time

# Create your views here.
def index(request):
    if 'find_gold_db' not in request.session:
        find_gold_db = {'score':0, 'activities':[]}
        request.session['find_gold_db'] =  find_gold_db    
    return render(request, 'second_app\index.html', request.session['find_gold_db'])   
       

        
def find_gold(request, building):
    print building    
    if request.method == 'POST':       
        golds = {'farm':random.randint(10, 20), 'cave':random.randint(5, 10), 'house':random.randint(2, 5),'casino':random.randint(-50, 50)}
        date_time =  time.localtime();
        activity = {'type':building, 'profit':golds[building], 'time':time.strftime("%Y %d %b, %I:%M %p", date_time)}
        find_gold_db = request.session['find_gold_db']
        print len(find_gold_db['activities'])
        find_gold_db['score'] += golds[building]
        find_gold_db['activities'].append(activity)
        request.session['find_gold_db'] =  find_gold_db
    return redirect('/')

def reset(request):
    if request.method == 'POST':       
       request.session['find_gold_db'] = {'score':0, 'activities':[]} 
    return redirect('/')       
