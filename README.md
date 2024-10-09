# Cadastro Processos

Sistema de Cadastro de Processos

## Pré-requisitos

Antes de começar, verifique se você atende aos seguintes requisitos:

- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 ou superior](https://visualstudio.microsoft.com/vs/)
- [Git](https://git-scm.com/)

## Configuração do Ambiente

1. **Clone o repositório**

   ```bash
   git clone https://github.com/usuario/nome-do-repositorio.git
   cd nome-do-repositorio

## Banco Sqlserve
Procure a pasta e o arquivo para encontrar os scripts do banco 
   - script/setup.sql

## Configuração da Conexão com o Banco de Dados

Antes de iniciar a aplicação, você precisa configurar a conexão com o banco de dados. Para isso, localize a seção `ConnectionStrings` no arquivo de configuração (appsettings.json) e insira o nome do seu servidor na string de conexão `DefaultConnection`.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=Processos;Trusted_Connection=True;TrustServerCertificate=True"
}
