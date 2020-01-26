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
            ViewBag.Flag2 = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(order => order.IsSubmitted) == null;
            ViewBag.Flag = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(order => !order.IsSubmitted) == null;
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
            order.IsSubmitted = false;
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
        [HttpPost]
        public ActionResult DeleteTreat(int joinId)
        {
            var joinEntry = _db.OrderTreat.FirstOrDefault(entry => entry.OrderTreatId == joinId);
            _db.OrderTreat.Remove(joinEntry);
            Order order = _db.Orders.FirstOrDefault(ord => ord.OrderId == joinEntry.OrderId);
            order.Price -= _db.Treats.FirstOrDefault(treat => treat.TreatId == joinEntry.TreatId).Price;
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = joinEntry.OrderId});
        }
        public async Task<ActionResult> AddTreat(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            Order thisOrder = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(orders => orders.OrderId == id);
            if (thisOrder == null)
            {
                return RedirectToAction("Details", new {id = id});
            }

            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisOrder);
        }
        [HttpPost]
        public ActionResult AddTreat(Order order, int TreatId)
        {
            if (TreatId != 0)
            {
                _db.OrderTreat.Add(new OrderTreat() {TreatId = TreatId, OrderId = order.OrderId});
            }
            order.Price += _db.Treats.FirstOrDefault(treat => treat.TreatId == TreatId).Price;
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = order.OrderId});
        }
         public async Task<ActionResult> Submit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            Order thisOrder = _db.Orders.Where(entry => entry.User.Id == currentUser.Id).Include(order => order.Treats).ThenInclude(join => join.Treat).FirstOrDefault(orders => orders.OrderId == id);
            if (thisOrder == null || thisOrder.IsSubmitted)
            {
                return RedirectToAction("Details", new {id = id});
            }
            return View(thisOrder);
        }
        [HttpPost, ActionName("Submit")]
        public ActionResult SubmitConfirmed(int id)
        {
            Order thisOrder = _db.Orders.FirstOrDefault(orders => orders.OrderId == id);
            if (thisOrder == null || thisOrder.IsSubmitted)
            {
                return RedirectToAction("Details", new {id = id});
            }
            thisOrder.IsSubmitted = true;
            _db.Entry(thisOrder).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = id});
        }
    }
}