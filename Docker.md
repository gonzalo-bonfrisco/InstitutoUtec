
Build
Parado sobre el directorio raiz de la solución correr el siguiente comando para hacr build del contenedor
C:\Users\gonzalo.bonfrisco\source\utec\Clases2022\Instituto>

docker build -f InstitutoApi\Dockerfile --force-rm -t institutoapi .

Run docker run -d -p 5000:5000 --name myapp institutoapi:latest

----

 PostgresDB in docker

 Referencia: https://www.code4it.dev/blog/run-postgresql-with-docker

 docker run --name myPostgresDb -p 5455:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Gonza1 -e POSTGRES_DB=InstitutoDB -d postgres

 ----

 Revision de logs instalacion vim

 https://unix.stackexchange.com/questions/336392/e-unable-to-locate-package-vim-on-debian-jessie-simplified-docker-container

 apt-get update

 apt-get install vim 


 ----
 Trabajar con https:
 Se debe configurar el certificado en el contenedor de docker
 https://keepinguptodate.com/pages/2020/12/net5-aspnet-docker-mac/

 el comando run queda de la siguiente forma luego de configurar el certificado
 docker run --name myapi --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="Gonza1" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/core5-website.pfx -v ${HOME}/.aspnet/https:/https/ institutoapi:latest  

 ----

Los contenedores trabajan en red para cominucarse 
Referencia: https://www.returngis.net/2020/12/como-funcionan-las-redes-en-docker/