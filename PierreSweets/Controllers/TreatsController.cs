using Microsoft.AspNetCore.Mvc;
using PierreSweets.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierreSweets.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierreSweetsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public TreatsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierreSweetsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public ActionResult Index()
    {
      List<Treat> userTreats = _db.Treats.ToList();
      return View(userTreats);
    }
    public ActionResult Create()
    {
      ViewBag.FlavorId = new MultiSelectList(_db.Flavors, "FlavorId", "Name");
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;

      _db.Treats.Add(treat);

      if (FlavorId != 0)
      {
          _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
          .Include(treat => treat.User)
          .Include(treat => treat.Flavors)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId == thisTreat.User.Id;
      return View(thisTreat);
    }

    // public ActionResult Edit(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
    //   ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
    //   return View(thisTreat);
    // }
    // [HttpPost]
    // public ActionResult Edit(Treat treat, int FlavorId)
    // {
    //   // Treat previousTreat = _db.Treats.Include(treats => treats.Flavors).ThenInclude(join => join.Flavor).FirstOrDefault(treats => treats.TreatId == treat.TreatId);
    //   TreatFlavor join = _db.TreatFlavor.FirstOrDefault(catTreat => catTreat.FlavorId == FlavorId && catTreat.TreatId == treat.TreatId);
    //   if (FlavorId != 0 && join == null)
    //   {
    //       _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId});
    //   }
    //   _db.Entry(treat).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddFlavor(int id)
    // {
    //     var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
    //     ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
    //     return View(thisTreat);
    // }
    // [HttpPost]
    // public ActionResult AddFlavor(Treat treat, int FlavorId)
    // {
    //     if (FlavorId != 0)
    //     {
    //         _db.TreatFlavor.Add(new TreatFlavor() {FlavorId = FlavorId, TreatId = treat.TreatId});
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    // public ActionResult Delete(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
    //   return View(thisTreat);
    // }
    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
    //   _db.Treats.Remove(thisTreat);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public ActionResult DeleteFlavor(int joinId)
    // {
    //     var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
    //     _db.TreatFlavor.Remove(joinEntry);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public ActionResult MarkAsCompleted(int id)
    // {
    //   var thisTreat = _db.Treats
    //       .FirstOrDefault(treat => treat.TreatId == id);
    //   thisTreat.Completed = true;
    //   _db.Entry(thisTreat).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    //  public ActionResult MarkAsUnCompleted(int id)
    // {
    //   var thisTreat = _db.Treats
    //       .FirstOrDefault(treat => treat.TreatId == id);
    //   thisTreat.Completed = false;
    //   _db.Entry(thisTreat).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}