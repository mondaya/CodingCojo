from django.shortcuts import render
#from django.http import HttpResponse

# Create your views here.
def index(request):
    return render(request, "disapparingnija/index.html")
    
    
# Create your views here.
def displayNinja(request, kind):

    kind  = "all" if kind == "" else kind
    
    ninja_map = {"blue":"leonardo.jpg", 
                 "orange":"michelangelo.jpg",
                 "red":"raphael.jpg",
                 "purple":"donatello.jpg",
                 "all":"tmnt.png"}
                 
    context = {'ninja_img':  ninja_map[kind] if kind in ninja_map else "notapril.jpg"}
    return render(request, "disapparingnija/index.html", context)
    