using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirst1toN.EntityFramework {
  public class Model : DbContext {
    public Model() : base("name=Model") {
    }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<CityOfBirth> CitiesOfBirth { get; set; }
  }

  public class Person {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? CityOfBirthId { get; set; }
    public CityOfBirth CityOfBirth { get; set; }
  }

  public class CityOfBirth {
    public int Id { get; set; }
    public ICollection<Person> Persons { get; }
    public string Name { get; set; }

    public CityOfBirth() {
      Persons = new List<Person>();
    }
  }
}