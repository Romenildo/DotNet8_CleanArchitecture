# Projeto

1. Criação da arquitetura do Projeto
    - Application
    - Database
    - Model
    - WebApi
2. Criação da Camada Model
    - Entities - Criação da entidade base e as entidades
    - Enums
    - Exceptions
    - Interfaces -  Criação do BaseRepository, e UnitOfWork
    - Settings
3. Criação da Camada Database
    - Adicionados os pacotes:
        - Microsoft.EntityFrameworkCore
        - Npgsql.EntityFrameworkCore.PostgreSQL (Banco PostgreSQL)
        - Referencia ao Projeto de Model
    - Context - Criado o appContext do EntityFrameworkCore
    - Mappings - Adicionado camada de mapeamento das entidades com o Banco
    - Repositories - Implementado as interfaces dos Repositories
    - Services - extensão de conecção com o banco de dados PostgreSQL
        - Adicionado a extensão no program.cs
    - Util - Funções uteis para as querys dos repository
    - Adicionado a conexão string do banco no AppSettings
4. Geração da migration
    - Adicionados os pacotes:
        - Microsoft.EntityFrameworkCore.Design(Database e WebApi)
        - Microsoft.EntityFrameworkCore.Tools
    - add-migration Sp02_Criacao_Initial -context AppDbContext
    - update-database -context AppDbContext
5.