* Fuente: 
. https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli 
. https://andrewlock.net/adding-ef-core-to-a-project-on-os-x/

- Instalar herramientas de CLI de EF core
	https://docs.microsoft.com/en-us/ef/core/cli/dotnet

	- Microsoft entityFramwork Core
	- Microsoft.EntityFrameworkCore.Design
	- Npgsql.EntityFrameworkcore.postgresSQL
	- Microsoft.EntityFrameworkCore.Tools

- Se crea el contexto de base de datos, InstutitoContext
- agregar conectionstring en appsettings.json
- Agregar al configureServices:
```
	 var connectionString = Configuration["DbContextSettings:ConnectionString"];
				services.AddDbContext<InstitutoContext>(
					opts => opts.UseNpgsql(connectionString)
				);
```

- Crear la migracion inicial 

	Add-Migration InitialCreate
	

- Crear la base de datos

	Update-Database
	