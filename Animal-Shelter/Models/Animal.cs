using System;

namespace AnimalShelter.Models;

public class Animal
{
  public int AnimalId { get; set; }
  public string AnimalName { get; set; }
  public DateTime Date { get; set; }
  public string Breed { get; set; }
  public Animal()
  {
    Date = DateTime.Now;
  }
}

public enum Breed
{
  Cat,
  Dog,
  Fish,
  Reptile,
  Other
}