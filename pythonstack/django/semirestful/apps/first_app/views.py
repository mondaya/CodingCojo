from django.shortcuts import render, redirect, HttpResponse
from models  import Product


# Create your views here.
def index(request):

    if request.method == 'POST':
        Product.objects.create(name=request.POST["product_name"],
                               description=request.POST["description"],
                               price=request.POST["price"]
                               )
        return redirect('products:home')
    context = {
            'products': Product.objects.all(),
            
    }
    return render(request, 'first_app/index.html', context )

def show_new(request):
    
    return render(request, 'first_app/add.html')
    
def show_product(request,  product_id):
    context = {
            'product':Product.objects.get(id=product_id)
        }
    return render(request, 'first_app/show.html', context )

def edit(request, product_id):
    context = {
            'product':Product.objects.get(id=product_id)
        }
    return render(request, 'first_app/edit.html', context )    
    
def update(request, product_id):
    if request.method == "POST":
        product = Product.objects.get(id=product_id)
        product.name = request.POST["product_name"]
        product.description = request.POST["description"]
        product.price = request.POST["price"]
        product.save()
    return redirect('products:home')
    
def remove(request):

    if request.method == 'POST':
        product = Product.objects.get(id=request.POST["product_id"])
        product.delete()
                              
    return redirect('products:home')
