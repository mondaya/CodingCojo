echo "You need myRepoName projectName yourPublicIP parameters
read -p "Press any key..."

sudo echo "[Unit]
Description=gunicorn daemon
After=network.target
[Service]
User=ubuntu
Group=www-data
WorkingDirectory=/home/ubuntu/$1
ExecStart=/home/ubuntu/$1/venv/bin/gunicorn --workers 3 --bind unix:/home/ubuntu/$1/$2.sock $2.wsgi:application
[Install]
WantedBy=multi-user.target">>  /etc/systemd/system/gunicorn.service

sudo systemctl daemon-reload

sudo systemctl start gunicorn

sudo systemctl enable gunicorn

sudo echo "server {
  listen 80;
  server_name $3;
  location = /favicon.ico { access_log off; log_not_found off; }
  location /static/ {
      root /home/ubuntu/$1;
  }
  location / {
      include proxy_params;
      proxy_pass http://unix:/home/ubuntu/$1/$2.sock;
  }
}" >> /etc/nginx/sites-available/$2


sudo ln -s /etc/nginx/sites-available/$2 /etc/nginx/sites-enabled
sudo nginx -t
sudo rm /etc/nginx/sites-enabled/default
sudo service nginx restart