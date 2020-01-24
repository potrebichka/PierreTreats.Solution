using System.Collections.Generic;
using System;

namespace PierreSweets.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<TreatFlavor>();
    }
    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public virtual ApplicationUser User { get; set; } 
    public ICollection<TreatFlavor> Flavors { get; }
  }
}