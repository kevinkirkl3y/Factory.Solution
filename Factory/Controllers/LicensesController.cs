using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;
    public LicensesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<License> model = _db.Licenses.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create (License license)
    {
      _db.Licenses.Add(license);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details (int id)
    {
      var thisLicense = _db.Licenses
      .Include(license => license.Engineers)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }
    public ActionResult Edit(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }
    [HttpPost]
    public ActionResult Edit(License license)
    {
      _db.Entry(license).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      _db.Licenses.Remove(thisLicense);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}