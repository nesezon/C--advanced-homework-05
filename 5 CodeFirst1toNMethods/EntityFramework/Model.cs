using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirst1toNMethods.EntityFramework {
  public class Model : DbContext {
    public Model() : base("name=Model") { }

    public virtual DbSet<Measure> Measures { get; set; }
    public virtual DbSet<Day> Days { get; set; }
  }

  public class Measure {
    public int Id { get; set; }
    public int Hour { get; set; }
    public int Temperature { get; set; }
    public int? DayId { get; set; }
    public Day Day { get; set; }
  }
  public class Day {
    public int Id { get; set; }
    public int Date { get; set; }
    public int? MaxTemperature { get; set; }
    public int? MinTemperature { get; set; }
    public int? MeasureCount { get; set; }
    public double? AvgTemperature { get; set; }
    public bool? IsBelowZero { get; set; }
    public ICollection<Measure> Measures { get; set; }
    public Day() {
      Measures = new List<Measure>();
    }
  }
}