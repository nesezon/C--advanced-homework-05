-- create database MyDatabase
CREATE DATABASE [MyDatabase]
GO
 
-- change owner to sa
USE [MyDatabase]
GO
ALTER AUTHORIZATION ON DATABASE::[MyDatabase] TO [sa]
GO
 
-- set recovery model to simple 
ALTER DATABASE [MyDatabase] SET RECOVERY SIMPLE 
GO

-- create table MyTable
CREATE TABLE [MyDatabase].[dbo].[MyTable] (
  [Id] INT IDENTITY PRIMARY KEY,
  [FirstName] NVARCHAR(50), 
  [LastName] NVARCHAR(50), 
  [Age] INT
)

-- insert data into the table
INSERT [MyDatabase].[dbo].[MyTable] ([FirstName], [LastName], [Age])
VALUES ('Иван', 'Иванов', 21),
       ('Андрей', 'Андреев', 48),
       ('Петр', 'Петров', 76),
       ('Алекс', 'Алексеев', 54),
       ('Егор', 'Егоров', 22),
       ('Степан', 'Степанов', 37)