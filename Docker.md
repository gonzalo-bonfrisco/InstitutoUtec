
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