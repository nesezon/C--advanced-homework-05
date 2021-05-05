using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodeFirst1toNMethods.EntityFramework;

namespace CodeFirst1toNMethods {
  class Program {
    static void Main(string[] args) {
      Database.SetInitializer(new DropCreateDatabaseAlways<Model>());
      using (Model db = new Model()) {

        var d1 = new Day { Date = 1 };
        d1.Measures.Add(new Measure { Hour = 0, Temperature = 1, Day = d1 });
        d1.Measures.Add(new Measure { Hour = 4, Temperature = 2, Day = d1 });
        d1.Measures.Add(new Measure { Hour = 8, Temperature = 3, Day = d1 });
        d1.Measures.Add(new Measure { Hour = 12, Temperature = 3, Day = d1 });
        d1.Measures.Add(new Measure { Hour = 16, Temperature = 4, Day = d1 });
        d1.Measures.Add(new Measure { Hour = 20, Temperature = 2, Day = d1 });

        var d2 = new Day { Date = 2 };
        d2.Measures.Add(new Measure { Hour = 0, Temperature = 0, Day = d2 });
        d2.Measures.Add(new Measure { Hour = 4, Temperature = 1, Day = d2 });
        d2.Measures.Add(new Measure { Hour = 8, Temperature = 1, Day = d2 });
        d2.Measures.Add(new Measure { Hour = 12, Temperature = 2, Day = d2 });
        d2.Measures.Add(new Measure { Hour = 16, Temperature = 1, Day = d2 });
        d2.Measures.Add(new Measure { Hour = 20, Temperature = 1, Day = d2 });

        var d3 = new Day { Date = 3 };
        d3.Measures.Add(new Measure { Hour = 0, Temperature = 1, Day = d3 });
        d3.Measures.Add(new Measure { Hour = 4, Temperature = 0, Day = d3 });
        d3.Measures.Add(new Measure { Hour = 8, Temperature = -1, Day = d3 });
        d3.Measures.Add(new Measure { Hour = 12, Temperature = 0, Day = d3 });
        d3.Measures.Add(new Measure { Hour = 16, Temperature = 1, Day = d3 });
        d3.Measures.Add(new Measure { Hour = 20, Temperature = 1, Day = d3 });

        db.Days.AddRange(new List<Day> { d1, d2, d3 });
        db.SaveChanges();

        ShowInfo(1, db);
        ShowInfo(2, db);
        ShowInfo(3, db);
      }
      Console.ReadKey();
    }

    private static void ShowInfo(int d, Model db) {
      var daily = db.Measures.Where(m => m.Day.Date == d);
      int MinTemperature = daily.Min(m => m.Temperature);
      int MaxTemperature = daily.Max(m => m.Temperature);
      int MeasureCount = daily.Count();
      double AvgTemperature = daily.Average(m => m.Temperature);
      bool IsBelowZero = daily.FirstOrDefault(m => m.Temperature < 0) != null;

      Console.WriteLine($"Day {d}:");
      Console.WriteLine("  Минимальная температура: {0}", MinTemperature);
      Console.WriteLine("  Максимальная температура: {0}", MaxTemperature);
      Console.WriteLine("  Кол-во измерений за день: {0}", MeasureCount);
      Console.WriteLine("  Средняя температура: {0}", AvgTemperature);
      Console.WriteLine("  Есть температура меньше нуля: {0}", IsBelowZero);

      db.Days.Find(d).MinTemperature = MinTemperature;
      db.Days.Find(d).MaxTemperature = MaxTemperature;
      db.Days.Find(d).MeasureCount = MeasureCount;
      db.Days.Find(d).AvgTemperature = AvgTemperature;
      db.Days.Find(d).IsBelowZero = IsBelowZero;
      db.SaveChanges();
    }
  }
}
