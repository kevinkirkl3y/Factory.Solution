using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    public readonly FactoryContext _db; 
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }
    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
      .Include(engineer => engineer.Licenses)
      .ThenInclude(join => join.License)
      .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
    public ActionResult Create()
    {
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LicenseType");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer, int LicenseId)
    {
      _db.Engineers.Add(engineer);
      if (LicenseId != 0)
      {
        _db.LicenseEngineer.Add(new LicenseEngineer() { LicenseId = LicenseId, EngineerId = engineer.EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LinceseType");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer engineer, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.LicenseEngineer.Add(new LicenseEngineer() { LicenseId = LicenseId, EngineerId = engineer.EngineerId});
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddLicense(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LicenseType");
      return View(thisEngineer); 
    }
    [HttpPost]
    public ActionResult AddLicense(Engineer engineer, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.LicenseEngineer.Add( new LicenseEngineer() { LicenseId = LicenseId, EngineerId = engineer.EngineerId});
      }
      _db.SaveChanges();
      return View("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteLicense(int joinId)
    {
      var joinEntry = _db.LicenseEngineer.FirstOrDefault(entry => entry.LicenseEngineerId == joinId);
      _db.LicenseEngineer.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}