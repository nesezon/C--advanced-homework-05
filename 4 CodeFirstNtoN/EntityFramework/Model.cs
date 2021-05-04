using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirstNtoN.EntityFramework {
  public class Model : DbContext {
    public Model() : base("name=Model") { }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<Profession> Professions { get; set; }
  }

  public class Person {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Language> Languages { get; set; }
    public ICollection<Profession> Professions { get; set; }
    public Person() {
      Languages = new List<Language>();
      Professions = new List<Profession>();
    }
  }

  public class Language {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Person> Persons { get; set; }
    public ICollection<Profession> Professions { get; set; }
    public Language() {
      Persons = new List<Person>();
      Professions = new List<Profession>();
    }
  }

  public class Profession {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Person> Persons { get; set; }
    public ICollection<Language> Languages { get; set; }
    public Profession() {
      Persons = new List<Person>();
      Languages = new List<Language>();
    }
  }
}