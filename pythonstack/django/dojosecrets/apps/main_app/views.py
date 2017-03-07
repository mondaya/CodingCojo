from django.shortcuts import render,  redirect, HttpResponse
from models import Post
from ..login_reg.models import User
# Create your views here.
def index(request):
   
    try:
        context = {
                'first_name': request.session['user'],
                'status': request.session['user_status'],   
                'popular':False                
            }
        secrects = Post.objects.is_user_in_post(request.session['user_id'])
        context['secrets'] = secrects[0]
        context['secrets_liked_user'] = secrects[1]
        
        return render( request, 'main_app/index.html', context)
    except KeyError:
            return redirect('home:signup')
    
def post(request):  
    # todo:
        # use the post model create a new post.
        # if this request is a post 
            # 1. use model to validate and create the post.
            # 2. the model should return post id, or error if the post creation is invalidated
         # if error,send flash message else render the page
    if request.method == 'POST':
        status = Post.objects.create_post(request.POST, request.session['user_id'])       
               
    
    return redirect('main_app:home')

def popular(request):  
    try:
        context = {
                'first_name': request.session['user'],
                'status': request.session['user_status'], 
                'popular':True                
            }
        secrects = Post.objects.popular_post(request.session['user_id'])
        context['secrets'] = secrects[0]
        context['secrets_liked_user'] = secrects[1]
        return render( request, 'main_app/index.html', context)
    except KeyError:
            return redirect('home:signup')
            
def like_post(request, post_id):  
    try:
        Post.objects.like_post(request.session['user_id'], post_id)
        return redirect('main_app:home')
    except KeyError:
        return redirect('home:signup')

def delete_post(request, post_id):  
    try:
        Post.objects.delete_post(request.session['user_id'], post_id)
        return redirect('main_app:home')
    except KeyError:
        return redirect('home:signup')        
   