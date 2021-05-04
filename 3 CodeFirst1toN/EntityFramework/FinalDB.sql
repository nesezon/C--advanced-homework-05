-- Результирующие скрипты автоматически созданных таблиц

CREATE TABLE [dbo].[CityOfBirths] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.CityOfBirths] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[People] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (MAX) NULL,
    [LastName]      NVARCHAR (MAX) NULL,
    [CityOfBirthId] INT            NULL,
    CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.People_dbo.CityOfBirths_CityOfBirthId] FOREIGN KEY ([CityOfBirthId]) REFERENCES [dbo].[CityOfBirths] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_CityOfBirthId]
    ON [dbo].[People]([CityOfBirthId] ASC);