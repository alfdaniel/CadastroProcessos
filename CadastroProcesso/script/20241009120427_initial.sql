Build started...
Build succeeded.
The Entity Framework tools version '8.0.7' is older than that of the runtime '8.0.8'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Processos] (
    [ProcessoId] uniqueidentifier NOT NULL,
    [NomeProcesso] nvarchar(120) NOT NULL,
    [Npu] nvarchar(20) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataVizualizacao] datetime2 NOT NULL,
    [Uf] nvarchar(max) NOT NULL,
    [Municipio] nvarchar(max) NOT NULL,
    [CodMunicipio] int NOT NULL,
    [Visualizado] bit NOT NULL,
    CONSTRAINT [PK_Processos] PRIMARY KEY ([ProcessoId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241009120427_initial', N'8.0.8');
GO

COMMIT;
GO


