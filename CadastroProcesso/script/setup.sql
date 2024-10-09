BEGIN
    CREATE DATABASE Processos;
END
GO

CREATE TABLE Processos.dbo.[Processos] (
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

INSERT INTO Processos.dbo.Processos (ProcessoId, NomeProcesso, Npu, DataCadastro, DataVizualizacao, Uf, Municipio, CodMunicipio, Visualizado)
VALUES
    (NEWID(), 'Processo 1', '77777777777777774312', GETDATE(), GETDATE(), 'SP', 'São Paulo', 3550308, 0),
    (NEWID(), 'Processo 2', '77777777777777774313', GETDATE(), GETDATE(), 'RJ', 'Rio de Janeiro', 3304557, 0),
    (NEWID(), 'Processo 3', '77777777777777774314', GETDATE(), GETDATE(), 'MG', 'Belo Horizonte', 3106200, 0),
    (NEWID(), 'Processo 4', '77777777777777774315', GETDATE(), GETDATE(), 'BA', 'Salvador', 2927408, 0),
    (NEWID(), 'Processo 5', '77777777777777774316', GETDATE(), GETDATE(), 'PR', 'Curitiba', 4106902, 0),
    (NEWID(), 'Processo 6', '77777777777777774317', GETDATE(), GETDATE(), 'SC', 'Florianópolis', 4205407, 0),
    (NEWID(), 'Processo 7', '77777777777777774318', GETDATE(), GETDATE(), 'RS', 'Porto Alegre', 4314902, 0),
    (NEWID(), 'Processo 8', '77777777777777774319', GETDATE(), GETDATE(), 'ES', 'Vitória', 3205309, 0),
    (NEWID(), 'Processo 9', '77777777777777774320', GETDATE(), GETDATE(), 'GO', 'Goiânia', 5208707, 0),
    (NEWID(), 'Processo 10', '77777777777777774321', GETDATE(), GETDATE(), 'PE', 'Recife', 2611606, 0),
    (NEWID(), 'Processo 11', '77777777777777774322', GETDATE(), GETDATE(), 'DF', 'Brasília', 5300108, 0),
    (NEWID(), 'Processo 12', '77777777777777774323', GETDATE(), GETDATE(), 'MT', 'Cuiabá', 5103403, 0),
    (NEWID(), 'Processo 13', '77777777777777774324', GETDATE(), GETDATE(), 'CE', 'Fortaleza', 2304400, 0),
    (NEWID(), 'Processo 14', '77777777777777774325', GETDATE(), GETDATE(), 'AM', 'Manaus', 1302603, 0),
    (NEWID(), 'Processo 15', '77777777777777774326', GETDATE(), GETDATE(), 'PR', 'Londrina', 4113700, 0),
    (NEWID(), 'Processo 16', '77777777777777774327', GETDATE(), GETDATE(), 'RN', 'Natal', 2403203, 0),
    (NEWID(), 'Processo 17', '77777777777777774328', GETDATE(), GETDATE(), 'AL', 'Maceió', 2704302, 0),
    (NEWID(), 'Processo 18', '77777777777777774329', GETDATE(), GETDATE(), 'PA', 'Belém', 1501402, 0),
    (NEWID(), 'Processo 19', '77777777777777774330', GETDATE(), GETDATE(), 'SE', 'Aracaju', 2800300, 0),
    (NEWID(), 'Processo 20', '77777777777777774331', GETDATE(), GETDATE(), 'PI', 'Teresina', 2211001, 0);
GO