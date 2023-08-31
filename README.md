# Account - API

- [Account - API](#account---api)
  - [Desenvolvimento, por onde começar](#desenvolvimento-por-onde-começar)
  - [Execução do projeto](#execução-do-projeto)
  - [Estrutura BackEnd](#estrutura-backend)

## Desenvolvimento, por onde começar

Passos para execução do projeto:

1. Abrir *Prompt de Comando* de sua preferência (**CMD** ou **PowerShell**);

2. clonar o projeto;

## Execução do projeto


1. Executar comandos dentro de **src\Bank.Infrastructure** do projeto:
~~~dotnet ef
dotnet ef --startup-project ..\Bank.API migrations add inicial
dotnet ef database update
~~~


2. Urls disponibilizadas:
* back-end: <http://localhost:49657/swagger/index.html>


## Estrutura BackEnd

Padrão das camadas do projeto:

1. **Bank.Domain**: domínio da aplicação, responsável por manter as *regras de negócio*;
2. **Bank.Data**: camada mais baixa, para acesso a dados;
3. **Bank.API**: responsável pela *disponibilização* dos endpoints da API;
5. **Bank.Application**: responsável pelo tramento de dados(request, response);
6. **Bank.Unit.Tests**: responsável pela camada de *testes unitários* dos projetos.

