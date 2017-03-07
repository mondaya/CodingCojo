sudo apt-get update
sudo apt-get install python-pip python-dev nginx git
sudo apt-get update
sudo pip install virtualenv
git clone https://github.com/mondaya/$1.git
cd $1
ls
read -p "Press any key..."
virtualenv venv
source venv/bin/activate
pip install -r requirements.txt
pip install django bcrypt django-extensions
pip install gunicorn


echo "ALLOWED_HOSTS = ['{{yourEC2.public.ip}}']  in settings file"
echo # add the line below to the bottom of the file
echo "STATIC_ROOT = os.path.join(BASE_DIR, "static/")"
read -p "Press any key..."
echo "cd .. to get back to the folder that holds manage.py(if needed)"
echo "python manage.py collectstatic #say yes"
python manage.py collectstatic #say yes
gunicorn --bind 0.0.0.0:8000 $2.wsgi:application

echo "ctrl-c"
echo " Now, deactivate your virtual environment."
ls

rm -Rf /etc/nginx/sites-enabled/sites-available