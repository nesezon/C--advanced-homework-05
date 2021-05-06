using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst1toNOperations.EntityFramework {
  public class Model : DbContext {
    public Model() : base("name=Model") { }

    public virtual DbSet<Number> Numbers { get; set; }
    public virtual DbSet<Zone> Zones { get; set; }
  }

  public class Number {
    public int Id { get; set; }
    public int Value { get; set; }
    public int? ZoneId { get; set; }
    public Zone Zone { get; set; }
  }

  public class Zone {
    public int Id { get; set; }
    public int ZoneStart { get; set; }
    public int ZoneEnd { get; set; }
    public ICollection<Number> Numbers { get; set; }
    public Zone() {
      Numbers = new List<Number>();
    }
  }
}