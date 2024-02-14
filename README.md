Este documento fornece instruções sobre como realizar migrações e atualizar o banco de dados usando o Entity Framework Core no contexto de um projeto .NET. Os comandos específicos mencionados são utilizados no Package Manager Console (no Visual Studio) para adicionar uma nova migração chamada "Blog" e atualizar o banco de dados com as alterações.
Pré-requisitos

Certifique-se de ter o Entity Framework Core instalado no seu projeto .NET.
Tenha o Package Manager Console (PMC) aberto no Visual Studio.
    
Passo 1: Adicionar uma Migração
No Package Manager Console, da Camada Blog.Infra execute o seguinte comando:

    Add-Migration Blog

Passo 2: Atualizar o Banco de Dados

Após adicionar a migração, é necessário aplicar as alterações ao banco de dados. Para fazer isso, siga estas etapas:
No Package Manager Console, da Camada Blog.Infra execute o seguinte comando:
    

    Update-Database
