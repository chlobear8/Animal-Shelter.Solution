using System;

namespace AnimalShelter.Models;

public class Animal
{
  public int AnimalId { get; set; }
  public string AnimalName { get; set; }
  public DateOnly Date { get; set; }
  public string Breed { get; set; }
  // Item constructor and methods omitted
}