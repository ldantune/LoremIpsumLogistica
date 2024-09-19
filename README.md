# LoremIpsumLogistica
# Configuração Inicial

## Projeto Angular

1. **Instalação das Dependências**

   Navegue até o diretório do projeto Angular e execute o seguinte comando para instalar todas as dependências:

   ```bash
   npm install

2. **Verificar e Configurar Variáveis de Ambiente**

Ajuste as configurações conforme necessário no arquivo src/environments/environment.ts. 
Certifique-se de que todas as variáveis necessárias estejam definidas corretamente.

Ajusta a rota da api de acordo com a porta que estiver rodando a aplicação .NET
**apiURL: 'http://localhost:5032/'**

3. **Iniciar o Servidor de Desenvolvimento**

ng serve

## Projeto .NET

1. **Restaurar as Dependências**

Navegue até o diretório do projeto .NET e execute o seguinte comando para restaurar as dependências e pacotes do projeto:
dotnet restore


2. **Configurar Variáveis de Ambiente do banco de dados**

Ajuste as variáveis de ambiente ou arquivos de configuração conforme necessário. 
Verifique o arquivo **appsettings.Development.json** para garantir que todas as configurações estejam corretas, **incluindo conexões de banco de dados** e outras configurações de ambiente.

# Criar o banco de dados com o nome **loremipsumlogistica** ou outro de acordo com as configuração da **ConnectionStrings**

# Executar o comando seguinte para criar as tabelas no banco de dados:

dotnet ef database update

3. **Compilar e Executar o Projeto**

Para compilar e executar o projeto, use os seguintes comandos:

dotnet build
dotnet run
