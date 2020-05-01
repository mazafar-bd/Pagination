# Pagination in EntityFramework Core

We can paginate any IQueryable<T> or IQueryable 
we can find the package in [nuget](https://www.nuget.org/packages/BS23.Pagination.EfCore)

## Usage

step 1.

execute the sql script named 'paginationdb.sql' from Pagination.Sample.WebAPI project folder

step 2.

change the connection strings as your database.

step 3.

select Pagination.Sample.WebAPI for console debug from drop-down to see the tsql statement  

or

run as iisexpress and change the .AddConsole(); to .AddDebug(); in startup.cs file to see the tsql in output window in visual studio
```csharp

 private readonly ILoggerFactory _consoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
              //.AddDebug();
        });
```

step 4.

after run you will see the swagger window where you can tryout the APIs
or
you can use Postman

step 5.

you can uninstall the nuget package from Pagination.Sample.WebAPI project
 <PackageReference Include="BS23.Pagination.EfCore" Version="1.1.1" />
 and add the reference from BS23.Pagination.EfCore project or vise versa



