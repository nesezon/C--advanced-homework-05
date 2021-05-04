using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNtoN.EntityFramework;

namespace CodeFirstNtoN {
  class Program {
    static void Main(string[] args) {
      Database.SetInitializer(new DropCreateDatabaseAlways<Model>());
      using (Model db = new Model()) {
        // Persons
        var p1 = new Person { Name = "Ivan Ivanov" };
        var p2 = new Person { Name = "Andrey Andreev" };
        var p3 = new Person { Name = "Petr Petrov" };
        var p4 = new Person { Name = "Alex Alexeev" };
        // Languages
        var l1 = new Language { Name = "Русский" };
        var l2 = new Language { Name = "Белорусский" };
        var l3 = new Language { Name = "Украинский" };
        var l4 = new Language { Name = "Английский" };
        // Professions
        var s1 = new Profession { Name = "Программист" };
        var s2 = new Profession { Name = "Учитель" };
        var s3 = new Profession { Name = "Таксист" };
        var s4 = new Profession { Name = "Космонавт" };
        
        p1.Languages = new List<Language> { l1, l2 };
        p1.Professions = new List<Profession> { s1 };

        p2.Languages = new List<Language> { l3, l1, l4 };
        p2.Professions = new List<Profession> { s1, s3 };

        p3.Languages = new List<Language> { l1, l3 };
        p3.Professions = new List<Profession> { s2 };

        p4.Languages = new List<Language> { l1, l4 };
        p4.Professions = new List<Profession> { s4 };

        db.Persons.AddRange(new List<Person> { p1, p2, p3, p4 });
        db.SaveChanges();

        foreach (var person in db.Persons) {
          Console.WriteLine(person.Name);
          string languages = "";
          foreach (var language in person.Languages) {
            languages += language.Name + "    ";
          }
          string professions = "";
          foreach (var profession in person.Professions) {
            professions += profession.Name + "    ";
          }
          if (!string.IsNullOrWhiteSpace(languages)) Console.WriteLine($"\t{languages.Trim()}");
          if (!string.IsNullOrWhiteSpace(professions)) Console.WriteLine($"\t{professions.Trim()}");
        }

        Console.ReadKey();
      }
    }
  }
}
