from django.conf.urls import url
import views
"""
    Name controllers\views in plural form (i.e. Products)
    Name each model singular (i.e. Product)
    Create 7 methods in your view \controller; refer to the routes in the wireframe for guidance
    index: Display all products
    show: Display a particular product
    new: Display a form to create a new product
    edit: Display a form to update a product
    create: Process information to create a new product
    update: Process information from the edit form and update the particular product
    destroy: Remove a product
    Feel free to reference the following table (in this case pets are the resource) to build RESTful routes. Note that this assignment only asks that you build a semi-RESTful application. Thats because we only expect you to use GET and POST verbs (not PUT, PATCH or DELETE), so you can't reuse URLs to the same extent.

    RESTful Routes:
    Using pets as an example resource:

    Action	HTTP Verb	Route Path	Function
    Retrieve all pets	GET	/pets	index
    Display form to create a new pet	GET	/pets/new	new
    Create a new pet	POST	/pets	create
    Display specific pet	GET	/pets/<id>	show
    Display form to update a specific pet	GET	/pets/<id>/edit	edit
    Update a specific pet	PUT or PATCH	/pets/<id>	update
    Delete a specific pet	DELETE	/pets/<id>	destroy
    For semi-RESTful architecture, you can append a /destroy to the destroy route.
"""
urlpatterns = [
    url(r'^$', views.index, name='home'), # show the products page 
    url(r'^new$', views.show_new, name='show_new'), # show the form to create a new product
    url(r'^$', views.index, name='create'), # send a post request to create the new product
    url(r'^show/(?P<product_id>\d+)$', views.show_product, name='show_product'), # show product details 
    url(r'^(?P<product_id>\d+)/edit$', views.edit, name='edit'), # show the to allow editing created product
    url(r'^(?P<product_id>\d+)/update$', views.update, name='update'), # update changes made to the created product
    url(r'^destroy$', views.remove, name='remove'), # show the form to confrim the product to destroy
     
]


