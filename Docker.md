
Build
Parado sobre el directorio raiz de la solución correr el siguiente comando para hacr build del contenedor
C:\Users\gonzalo.bonfrisco\source\utec\Clases2022\Instituto>

docker build -f InstitutoApi\Dockerfile --force-rm -t institutoapi .

Run
docker run -d -p 5000:5000 --name myapp institutoapi:latest

Nota: Agregamos la siguiente linea en Program:
 webBuilder.UseUrls("http://*:5000"); //Add this line para que funcione con docker 
 https://georgestocker.com/2017/01/31/fix-for-asp-net-core-docker-service-not-being-exposed-on-host/




 PostgresDB in docker

 Referencia: https://www.code4it.dev/blog/run-postgresql-with-docker

 docker run --name myPostgresDb -p 5455:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Gonza1 -e POSTGRES_DB=InstitutoDB -d postgres


 Revision de logs instalacion vim

 https://unix.stackexchange.com/questions/336392/e-unable-to-locate-package-vim-on-debian-jessie-simplified-docker-container



 Trabajar con https:
 Se debe configurar el certificado en el contenedor de docker
 https://keepinguptodate.com/pages/2020/12/net5-aspnet-docker-mac/

 el comando run queda de la siguiente forma luego de configurar el certificado
 docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="Gonza1" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/core5-website.pfx -v ${HOME}/.aspnet/https:/https/ institutoapi:latest  


 Creacion de red en docker
 https://www.josedomingo.org/pledin/2020/02/redes-en-docker/

 docker network create mired

 Comando para crear postgres en la red
 docker run --name myPostgresDbRed --network mired -p 5460:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Gonza1 -e POSTGRES_DB=InstitutoDB -d postgres

comando api con https dentro de la red
 docker run --name myapi --network mired --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="Gonza1" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/core5-website.pfx -v ${HOME}/.aspnet/https:/https/ institutoapi:latest