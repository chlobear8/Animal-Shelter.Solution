using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers;

public class AnimalsController : Controller
{
  private readonly AnimalShelterContext _db;

  public AnimalsController(AnimalShelterContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Animal> model = _db.Animals.ToList();
    return View(model);
  }

  [HttpPost]
  public ActionResult Index(string sortMethod)
  {
    List<Animal> model = _db.Animals.ToList();

    if (sortMethod == null)
    {
      return View(model);
    }

    List<Animal> sortedAnimals = model.OrderBy(animal => typeof(Animal).GetProperty(sortMethod).GetValue(animal)).ToList();
    return View(sortedAnimals);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Animal animal)
  {
    _db.Animals.Add(animal);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    return View(thisAnimal);
  }
}

