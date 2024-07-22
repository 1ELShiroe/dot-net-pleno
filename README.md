# **dot-net-pleno**

Este repositório tem por finalidade, disponibilizar conteúdo para execução da avaliação para desenvolvedor pleno utilizando .Net 8 e SQL Server. 
A descrição da avaliação está descrita em nosso [Wiki](https://github.com/StallosTecnologia/dot-net-pleno/wiki "Wiki").

# Migration
$env:DBCONN="Server=localhost,1433;Database=master;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";

Visual Studio:
    - Add-Migration InitialCreate -OutputDir Database/Entities/Migrations -Context Context

CLI:
    - dotnet ef migrations add InitialDb --output-dir Database/Migrations --context Context
    - dotnet ef database update