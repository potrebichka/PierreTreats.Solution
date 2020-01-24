using System.Collections.Generic;
using System;

namespace PierreSweets.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<TreatFlavor>();
    }

    public int FlavorId { get; set; }
    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; } 
    public ICollection<TreatFlavor> Treats { get; }
  }
}