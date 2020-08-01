IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Plano] (
    [IdPlano] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Sigla] nvarchar(10) NOT NULL,
    [Descricao] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Plano] PRIMARY KEY ([IdPlano])
);

GO

CREATE TABLE [Cliente] (
    [IdCliente] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Cpf] nvarchar(15) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [IdPlano] int NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([IdCliente]),
    CONSTRAINT [FK_Cliente_Plano_IdPlano] FOREIGN KEY ([IdPlano]) REFERENCES [Plano] ([IdPlano]) ON DELETE CASCADE
);

GO

CREATE TABLE [Dependente] (
    [IdDependente] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] int NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Dependente] PRIMARY KEY ([IdDependente]),
    CONSTRAINT [FK_Dependente_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([IdCliente]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Cliente_Cpf] ON [Cliente] ([Cpf]);

GO

CREATE UNIQUE INDEX [IX_Cliente_Email] ON [Cliente] ([Email]);

GO

CREATE INDEX [IX_Cliente_IdPlano] ON [Cliente] ([IdPlano]);

GO

CREATE INDEX [IX_Dependente_ClienteId] ON [Dependente] ([ClienteId]);

GO

CREATE UNIQUE INDEX [IX_Plano_Sigla] ON [Plano] ([Sigla]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200709000107_Initial', N'3.1.5');

GO

