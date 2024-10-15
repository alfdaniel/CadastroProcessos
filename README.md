# Cadastro Processos

Sistema de Cadastro de Processos desenvolvido com **ASP.NET Core MVC 8**.

## Pré-requisitos

Antes de começar, verifique se você atende aos seguintes requisitos:

- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 ou superior](https://visualstudio.microsoft.com/vs/)
- [Git](https://git-scm.com/)

## Configuração do Ambiente

1. **Clone o repositório**

   ```bash
   git clone https://github.com/alfdaniel/CadastroProcessos.git

## Banco de Dados SQL Server

Para configurar o banco de dados, você precisará executar os scripts fornecidos. 

1. **Localize os Scripts**: Navegue até a pasta onde os scripts do banco de dados estão armazenados:
    -script/setup.sql
   
3. Alternativamente, você pode acessar o script diretamente no repositório através do seguinte link: 
https://github.com/alfdaniel/CadastroProcessos/blob/master/CadastroProcesso/script/setup.sql
     
4. **Execute o Script**: Abra o SQL Server Management Studio (SSMS) e execute o script, verifique se o database e a tabela foram criadas.


## Configuração da Conexão com o Banco de Dados

Antes de iniciar a aplicação, você precisa configurar a conexão com o banco de dados. Para isso, localize a seção `ConnectionStrings` no arquivo de configuração (appsettings.Development.json) e insira o nome do seu servidor na string de conexão `DefaultConnection` no lugar `localhost`.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=Processos;Trusted_Connection=True;TrustServerCertificate=True"
}
```

## Rodando o projeto
Após essas etapas entre no terminal da raiz do projeto e rode o comando

```bash
   dotnet run

