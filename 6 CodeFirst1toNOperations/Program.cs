using System;
using System.Data.Entity;
using System.Linq;
using CodeFirst1toNOperations.EntityFramework;

namespace CodeFirst1toNOperations {
  class Program {
    static void Main(string[] args) {
      Database.SetInitializer(new DropCreateDatabaseAlways<Model>());
      using (Model db = new Model()) {
        // вывод лога SQL запросов
        //db.Database.Log = (s => Console.WriteLine(s));
        
        // Добавляю числовые зоны
        Zone[] zones = {
          new Zone { ZoneStart = 0, ZoneEnd = 9 },
          new Zone { ZoneStart = 10, ZoneEnd = 19 },
          new Zone { ZoneStart = 20, ZoneEnd = 29 },
          new Zone { ZoneStart = 30, ZoneEnd = 39 },
          new Zone { ZoneStart = 40, ZoneEnd = 49 }
        };

        // Заполнение зон
        Random rnd = new Random();
        for (int i = 0; i < 50; i++) {
          int newNumber = rnd.Next(0, 50);
          for (int j = 0; j < zones.Length; j++) {
            if (newNumber >= zones[j].ZoneStart && newNumber <= zones[j].ZoneEnd) {
              zones[j].Numbers.Add(new Number { Value = newNumber });
              break;
            }
          }
        }

        db.Zones.AddRange(zones);
        db.SaveChanges();

        var inTotal = from n in db.Numbers
                      join z in db.Zones on n.ZoneId equals z.Id
                      select new { n.Value, From = z.ZoneStart, To = z.ZoneEnd };

        var grouped = from n in inTotal
          group n by n.From;

        foreach (var group in grouped) {
          bool firstPass = true;
          foreach (var number in group) {
            if (firstPass) Console.WriteLine($"{number.From} .. {number.To}");
            Console.WriteLine($"   {number.Value}");
            firstPass = false;
          }
        }

        Console.ReadKey();
      }
    }
  }
}
