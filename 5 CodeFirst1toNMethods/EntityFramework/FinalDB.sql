-- Результирующие скрипты автоматически созданных таблиц

CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);

GO
CREATE TABLE [dbo].[Days] (
    [Id]             INT        IDENTITY (1, 1) NOT NULL,
    [Date]           INT        NOT NULL,
    [MaxTemperature] INT        NULL,
    [MinTemperature] INT        NULL,
    [MeasureCount]   INT        NULL,
    [AvgTemperature] FLOAT (53) NULL,
    [IsBelowZero]    BIT        NULL,
    CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Measures] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [Hour]        INT NOT NULL,
    [Temperature] INT NOT NULL,
    [DayId]       INT NULL,
    CONSTRAINT [PK_dbo.Measures] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Measures_dbo.Days_DayId] FOREIGN KEY ([DayId]) REFERENCES [dbo].[Days] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_DayId]
    ON [dbo].[Measures]([DayId] ASC);