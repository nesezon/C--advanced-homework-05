using System;
using System.Collections.Generic;
using System.Data.Entity;
using CodeFirst1toN.EntityFramework;

namespace CodeFirst1toN {
  class Program {
    static void Main(string[] args) {
      Database.SetInitializer(new DropCreateDatabaseAlways<Model>());
      using (Model db = new Model()) {

        // Добавляем CitiesOfBirth
        var c1 = new CityOfBirth { Name = "Гомель" };
        var c2 = new CityOfBirth { Name = "Киев" };
        var c3 = new CityOfBirth { Name = "Париж" };
        var c4 = new CityOfBirth { Name = "Лейпциг" };
        db.CitiesOfBirth.AddRange(new List<CityOfBirth> { c1, c2, c3, c4 });
        db.SaveChanges();

        // Добавляем Person-ов
        var p1 = new Person { FirstName = "Ivan", LastName = "Ivanov", CityOfBirth = c3 };
        var p2 = new Person { FirstName = "Andrey", LastName = "Andreev", CityOfBirth = c1 };
        var p3 = new Person { FirstName = "Petr", LastName = "Petrov", CityOfBirth = c4 };
        var p4 = new Person { FirstName = "Alex", LastName = "Alexeev", CityOfBirth = c2 };
        var p5 = new Person { FirstName = "Egor", LastName = "Egorov", CityOfBirth = c2 };
        var p6 = new Person { FirstName = "Stepan", LastName = "Stepanov", CityOfBirth = c1 };
        db.Persons.AddRange(new List<Person> { p1, p2, p3, p4, p5, p6 });
        db.SaveChanges();

        foreach (var CityOfBirth in db.CitiesOfBirth.Include(c => c.Persons)) {
          Console.WriteLine(CityOfBirth.Name);
          string txt = "";
          foreach (var Persons in CityOfBirth.Persons) {
            txt += "\"" + Persons.FirstName + " " + Persons.LastName + "\"    ";
          }
          if (!string.IsNullOrWhiteSpace(txt)) Console.WriteLine($"\t{txt.Trim()}");
        }
      }

      Console.ReadKey();
    }
  }
}
