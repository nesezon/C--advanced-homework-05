using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst1toNOperations.EntityFramework {
  public class Model : DbContext {
    // Контекст настроен для использования строки подключения "Model" из файла конфигурации  
    // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
    // "CodeFirst1toNOperations.EntityFramework.Model" в экземпляре LocalDb. 
    // 
    // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model" 
    // в файле конфигурации приложения.
    public Model()
        : base("name=Model") {
    }

    // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
    // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

    // public virtual DbSet<MyEntity> MyEntities { get; set; }
  }

  //public class MyEntity
  //{
  //    public int Id { get; set; }
  //    public string Name { get; set; }
  //}
}