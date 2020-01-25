# oDoT

## Как развернуть
Подразумевается что приложение будет работать на Linux. 

Для работы приложения, на машине, необходимо установить следующие ПО:
- .Net Core 3.1 Runtime
- web-сервер nginx

Перед развертыванием в конфигах нужно указать правильные ссылки на АПИ и ФРОНТ(для CORS)

### Для Backend
После установки необходимого ПО нужно подготовоить окружение для АПИ:
- создать пользователя, из под которого будет работать приложение
    > sudo useradd -s /usr/sbin/nologin -r {{userName}}  
    > sudo mkhomedir_helper {{userName}}   
- создать каталог в котором будет размещено приложение:
    > sudo mkdir -p /opt/{{serviceName}}/backend/app  
    > sudo mkdir /opt/{{serviceName}}/backend/app_data  
    > sudo chown -R {{userName}}:{{userName}} /opt/{{serviceName}}/backend  
    > sudo chmod 770 -R /opt/{{serviceName}}/backend  
- создать unit для SystemD:
    > sudo nano /etc/systemd/system/{{serviceName}}.service
- заполнить его по примеру:
    > [Unit]  
    > Description=Example .NET Web API App running on Linux SystemD  
    >   
    > [Service]  
    > WorkingDirectory=/opt/{{serviceName}}/app/backend  
    > ExecStart=/usr/bin/dotnet /opt/{{serviceName}}/backend/app/hellomvc.dll  
    > Restart=always  
    > \# Restart service after 10 seconds if the dotnet service crashes:  
    > RestartSec=10  
    > KillSignal=SIGINT  
    > SyslogIdentifier={{serviceName}}  
    > User={{userName}}  
    > Environment=ASPNETCORE_ENVIRONMENT=Production  
    > Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false  
    >   
    > [Install]  
    > WantedBy=multi-user.target 
- На CentOS для раоты приложения необходимо открыть порты:
    > sudo firewall-cmd --zone=public --permanent --add-port={{port}}/tcp  
    > sudo firewall-cmd --reload   
- Запуск приложения:
    > sudo systemctl {{serviceName}} start

### Для Frontend
После установки необходимого ПО нужно подготовоить окружение для ФРОНТА:
- установить nginx;  
- создать каталог в котором будет размещено приложение:
    > sudo mkdir -p /opt/{{serviceName}}/frontend/app  
    > sudo chown -R {{userName}}:{{userName}} /opt/{{serviceName}}/frontend  
    > sudo chmod 770 -R /opt/{{serviceName}}/frontend  
- Добавить файл конфигурации сайты в nginx:
    > sudo nano /etc/nginx/sites-avalible/{{siteName}}.conf
- Заполнить его по примеру:
    > server {  
    >     listen       80 default_server;  
    >     listen       [::]:80 default_server;  
    >     server_name  _;  
    >     root          /opt/{{serviceName}}/frontend/app;  
    > 
    >     # Load configuration files for the default server block.  
    >     include /etc/nginx/default.d/*.conf;  
    > 
    >     location / { 
    >             try_files $uri$args $uri$args/ /index.html; 
    >     }  
    > }  
- при необходимости добавить сертификат и настроить его;
- для CentOS необходимо отурыть порт на файрволе:
    > sudo firewall-cmd --zone=public --permanent --add-port=80/tcp  
    > sudo firewall-cmd --reload 
- проверить конфигурацию nginx:
    > sudo /usr/sbin/nginx -t    
- Перезагрузить nginx:
    > sudo systemctl restart nginx  

## Для проверки работы без развертывания
Для запуска отладки необхождимо установить ПО:
- nodeJs
- Angular-cli
- net core 3.1 SDK
- VisualStudio Code
- Git

### Для запуска отладки
- Клонировать репозиторий: https://github.com/py6jlb/oDoT.git
- Открыть папку с проектом в VSCode;
- Выполнить команду:
    > dotnet restore  
- Запустить отладку проекта WebApi(нажать f5, или кнопку play в интерфейсе);
- Открыть папку с репозиторием перейти в каталог AngularClient и открыть ее в терминале;
- Выполнить команду:
    > npm i  
- Выполнить команду:
    > ng serve
- Отркыть сайт(ссыдка будет в косоле) в браузере;

