<h2>PARA O BACKEND</h2>

cd DotnetFullstack

dotnet restore

dotnet build

dotnet run

_Se precisar rodar migrations do Entity Framework, use:_

dotnet ef migrations add NomeDaMigration

dotnet ef database update


<h2>PARA O FRONTEND</h2>

cd dotnetfullstack-front

npm install

ng serve

ACESSE http://localhost:4200
