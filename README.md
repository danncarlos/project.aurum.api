# project.aurum

# CRUD .NET

CRUD utilizando .net 8

### Usando
* .NET 8
* SQLServer (docker)

### Rodando

#### Backend

1 - Restaure os pacotes nuget

2 - Rodar Docker Compose

Somente esses passos já vão garantir o backend, caso nãos seja possivel rodar com docker, deve ajustar a ConnectionStrings no `appsettings.json` apontando para um banco local valido.

Migrations (construção de banco e seed) serão aplicadas no startup da aplicação.

FrontEnd:> https://github.com/danncarlos/project.aurum.web
