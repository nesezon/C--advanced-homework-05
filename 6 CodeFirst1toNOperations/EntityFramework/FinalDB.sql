-- Результирующие скрипты автоматически созданных таблиц

CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);

GO
CREATE TABLE [dbo].[Zones] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ZoneStart] INT NOT NULL,
    [ZoneEnd]   INT NOT NULL,
    CONSTRAINT [PK_dbo.Zones] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Numbers] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Value]  INT NOT NULL,
    [ZoneId] INT NULL,
    CONSTRAINT [PK_dbo.Numbers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Numbers_dbo.Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zones] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[Numbers]([ZoneId] ASC);