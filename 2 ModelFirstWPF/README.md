C# Advanced. Homework 05. Task 2
## ModelFirstWPF

После cоздания модели выполнил "Сформировать базу на основе модели...". Пустая база данных создалась успешно.
При генерации скриптов таблицы получил ошибку:

 > Не удается использовать выражение типа System.Data.Entity.Core.Metadata.Edm.EdmItemCollection для типа возвращаемого значения

>Expression of type 'System.Data.Entity.Core.Metadata.Edm.EdmItemCollection' cannot be used for return type 'System.Data.Entity.Core.Metadata.Edm.EdmItemCollection').

Получилось исправить - сделал сначала "Обновить модель из базы данных".
Потом закрыл Visual Studio. Открыл и снова сделал "Сформировать базу на основе модели..."

Скрипты для создания базы, таблицы и наполнения последней данными лежат в файле [EntityFramework/Model.edmx.sql](https://github.com/nesezon/C--advanced-homework-05/blob/main/2%20ModelFirstWPF/EntityFramework/Model.edmx.sql)

Строка подключения в файле [App.config](https://github.com/nesezon/C--advanced-homework-05/blob/main/2%20ModelFirstWPF/App.config). В ней необходимо исправить IP сервера, логин и пароль.