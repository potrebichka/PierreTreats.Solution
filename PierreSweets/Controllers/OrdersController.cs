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
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly PierreSweetsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrdersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierreSweetsContext db)
        {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
        }
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            List<Order> userOrders = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).ToList();
            ViewBag.Name = currentUser.UserName;
            return View(userOrders);
        }
        public ActionResult Create()
        {
            ViewBag.TreatId = new MultiSelectList(_db.Treats, "TreatId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Order order, List<int> TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            order.User = currentUser;
            double price = 0;
            _db.Orders.Add(order);
            if (TreatId.Count != 0)
            {
                foreach(int id in TreatId)
                {
                    _db.OrderTreat.Add(new OrderTreat() { OrderId = order.OrderId, TreatId = id });
                    price += _db.Treats.FirstOrDefault(treat => treat.TreatId == id).Price;
                }
            }
            order.Price = price;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // public ActionResult Details(int id)
        // {
        //   Flavor thisFlavor = _db.Flavors
        //       .Include(flavor => flavor.User)
        //       .Include(flavor => flavor.Treats)
        //       .ThenInclude(join => join.Treat)
        //       .FirstOrDefault(flavor => flavor.FlavorId == id);
        //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //   ViewBag.IsCurrentUser = userId == thisFlavor.User.Id;
        //   return View(thisFlavor);
        // }
        // [Authorize]
        // public async Task<ActionResult> Edit(int id)
        // {
        //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //   var currentUser = await _userManager.FindByIdAsync(userId);
        //   Flavor thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
        //   if (thisFlavor == null)
        //   {
        //     return RedirectToAction("Details", new {id = id});
        //   }
        //   return View(thisFlavor);
        // }
        // [HttpPost]
        // public ActionResult Edit(Flavor flavor)
        // {
        //   _db.Entry(flavor).State = EntityState.Modified;
        //   _db.SaveChanges();
        //   return RedirectToAction("Index");
        // }
        // [Authorize]
        // public async Task<ActionResult> Delete(int id)
        // {
        //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //   var currentUser = await _userManager.FindByIdAsync(userId);

        //   Flavor thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
        //   if (thisFlavor == null)
        //   {
        //     return RedirectToAction("Details", new {id = id});
        //   }
        //   return View(thisFlavor);
        // }
        // [HttpPost, ActionName("Delete")]
        // public ActionResult DeleteConfirmed(int id)
        // {
        //   Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
        //   _db.Flavors.Remove(thisFlavor);
        //   _db.SaveChanges();
        //   return RedirectToAction("Index");
        // }
        
    }
}