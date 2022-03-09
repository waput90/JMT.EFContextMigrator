# Entity Framework Automatic Migrator for Dotnet Core 3.X
when building application most likely using the Code First approach running migration to command is pretty sloppy, i just build this library to make the developers run their API or WEB app without concerning running migration to production without manually commanding for each environment

## Usage

1. You need to make sure your startup context registered properly

```
public void ConfigureServices(IServiceCollection services)
{
    // you can always choose your database if its MySQL or MSSQL as long as its using EF
    services.AddDbContextPool<YOUR_CONTEXT_HERE>(option =>
        option.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

    services.AddDbContext<YOUR_CONTEXT_HERE>(option =>
        option.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

```

2. Register the middleware migrator for automatic migration

```
using JMT.EFContextMigrator.Core

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  // some code here
  app.RegisterMigratorMiddleware<YOUR_CONTEXT_HERE>();

```

its pretty simple right? :D
