# cd into your project directory
pip freeze > requirements.txt
cd ..
touch .gitignore
echo " *.pyc" > .gitignore
echo " venv/" >> .gitignore
git init
git add --all
git commit -m "initial commit"

git remote add origin https://github.com/mondaya/d-appointments.git
git push origin master



git clone https://github.com/mondaya/d-appointments.git