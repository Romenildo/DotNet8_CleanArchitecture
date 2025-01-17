# Projeto

Projeto de uma web api em dotnet 8.0, com arquitetura de clean arquiteture.   
Criação base do projeto para ir implementando as funcionalidades que o .net dispoe:   
    - Identity - refit - hub - hangfire- closedXML - -jobs - Arquivos - notificacoes- importacoes -EmailSender -


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
5. Criação da Camada Application (Core)
    - Adicionados os pacotes:
        - AutoMapper.Extensions.Microsoft.DependencyInjection
        - FluentValidation
        - FluentValidation.AspNetCore
        - MediatR
    - Criação do Service extensios para configurar o fluentValidation, mediatR e Automapper no program.cs
    - Criação do Fluent Validation para validar no middleware os dados enviados nas requisicoes
    - Criação dos UseCases(falta criar IUseCaseBase)
6. Criação da camada de WebAPI
    - Adicionado Controllers
    - habilitado cors da aplicação
---
### Identity
7. Adicionando a Autenticação
    - Adicionados os pacotes:
        - Microsoft.AspNetCore.Authentication.JwtBearer
        - Microsoft.AspNetCore.Identity.EntityFrameworkCore
    - Configrando o DbContext para IdentityDbContext
    - Configurando o builder Services
    - Gerando migrations do Identity   
8. Gerando Jwt Token
    - Adicionando as informações para gerar o token no appSettings
    - Alterado Entidade do IdentityUser
    - Criado os Dtos de login, register e token
    - Criação do service ITokenService
    - Geração do Token