-- Результирующие скрипты автоматически созданных таблиц

CREATE TABLE [dbo].[Languages] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Languages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[People] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Professions] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Professions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[PersonLanguages] (
    [Person_Id]   INT NOT NULL,
    [Language_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.PersonLanguages] PRIMARY KEY CLUSTERED ([Person_Id] ASC, [Language_Id] ASC),
    CONSTRAINT [FK_dbo.PersonLanguages_dbo.People_Person_Id] FOREIGN KEY ([Person_Id]) REFERENCES [dbo].[People] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.PersonLanguages_dbo.Languages_Language_Id] FOREIGN KEY ([Language_Id]) REFERENCES [dbo].[Languages] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Person_Id]
    ON [dbo].[PersonLanguages]([Person_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Language_Id]
    ON [dbo].[PersonLanguages]([Language_Id] ASC);

GO
CREATE TABLE [dbo].[ProfessionLanguages] (
    [Profession_Id] INT NOT NULL,
    [Language_Id]   INT NOT NULL,
    CONSTRAINT [PK_dbo.ProfessionLanguages] PRIMARY KEY CLUSTERED ([Profession_Id] ASC, [Language_Id] ASC),
    CONSTRAINT [FK_dbo.ProfessionLanguages_dbo.Professions_Profession_Id] FOREIGN KEY ([Profession_Id]) REFERENCES [dbo].[Professions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ProfessionLanguages_dbo.Languages_Language_Id] FOREIGN KEY ([Language_Id]) REFERENCES [dbo].[Languages] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Profession_Id]
    ON [dbo].[ProfessionLanguages]([Profession_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Language_Id]
    ON [dbo].[ProfessionLanguages]([Language_Id] ASC);

GO
CREATE TABLE [dbo].[ProfessionPersons] (
    [Profession_Id] INT NOT NULL,
    [Person_Id]     INT NOT NULL,
    CONSTRAINT [PK_dbo.ProfessionPersons] PRIMARY KEY CLUSTERED ([Profession_Id] ASC, [Person_Id] ASC),
    CONSTRAINT [FK_dbo.ProfessionPersons_dbo.Professions_Profession_Id] FOREIGN KEY ([Profession_Id]) REFERENCES [dbo].[Professions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ProfessionPersons_dbo.People_Person_Id] FOREIGN KEY ([Person_Id]) REFERENCES [dbo].[People] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Profession_Id]
    ON [dbo].[ProfessionPersons]([Profession_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Person_Id]
    ON [dbo].[ProfessionPersons]([Person_Id] ASC);