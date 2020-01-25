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

        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Order thisOrder = _db.Orders
                .Include(order => order.User)
                .Include(order => order.Treats)
                .ThenInclude(join => join.Treat)
                .FirstOrDefault(order => order.OrderId == id);
            if (userId != thisOrder.User.Id)
            {
                return Redirect("Index");
            }
            return View(thisOrder);
        }
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var currentUser = await _userManager.FindByIdAsync(userId);

          Order thisOrder = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(order => order.OrderId == id);
          if (thisOrder == null)
          {
            return RedirectToAction("Details", new {id = id});
          }
          return View(thisOrder);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
          _db.Entry(order).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Details", new {id = order.OrderId});
        }
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var currentUser = await _userManager.FindByIdAsync(userId);

          Order thisOrder = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).Include(order => order.Treats).ThenInclude(join => join.Treat).FirstOrDefault(orders => orders.OrderId == id);
          if (thisOrder == null)
          {
            return RedirectToAction("Details", new {id = id});
          }
          return View(thisOrder);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          Order thisOrder = _db.Orders.FirstOrDefault(flavors => flavors.OrderId == id);
          _db.Orders.Remove(thisOrder);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }  
    }
}