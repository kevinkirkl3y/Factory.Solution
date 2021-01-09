using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    public readonly FactoryContext _db; 
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
      .Include(machine => machine.Licenses)
      .ThenInclude(join => join.License)
      .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Create()
    {
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LicenseType");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine, int LicenseId)
    {
      _db.Machines.Add(machine);
      if (LicenseId != 0)
      {
        _db.MachineLicense.Add(new MachineLicense() { LicenseId = LicenseId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LinceseType");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult Edit(Machine machine, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.MachineLicense.Add(new MachineLicense() { LicenseId = LicenseId, MachineId = machine.MachineId});
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddLicense(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "LicenseType");
      return View(thisMachine); 
    }
    [HttpPost]
    public ActionResult AddLicense(Machine machine, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.MachineLicense.Add( new MachineLicense() { LicenseId = LicenseId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return View("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteLicense(int joinId)
    {
      var joinEntry = _db.MachineLicense.FirstOrDefault(entry => entry.MachineLicenseId == joinId);
      _db.MachineLicense.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}