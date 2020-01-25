using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierreSweets.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    [Display(Name = "Order description")]
    public string Description { get; set; }
    public double Price { get; set; }
    public virtual ApplicationUser User{ get; set; }
    public virtual List<OrderTreat> Treats {get;set;}
  }
}