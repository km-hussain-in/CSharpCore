<h4>Dependency injection and view components</h4>

<pre>
dotnet new web
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
mkdir Models
mkdir Controllers
mkdir ViewComponents
mkdir Views
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
</pre>

