echo "name of the app %1 for project folder %2"
python ../manage.py startapp %1
cd %1
mkdir "templates/%1"
touch urls.py
cd ../../

python manage.py runserver