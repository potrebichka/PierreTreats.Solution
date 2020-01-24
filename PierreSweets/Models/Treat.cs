using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierreSweets.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<TreatFlavor>();
    }
    public int TreatId { get; set; }
    [Display(Name = "Treat name")]
    public string Name { get; set; }
    [Display(Name = "Treat description")]
    public string Description { get; set; }
    public double Price { get; set; }
    public virtual ApplicationUser User { get; set; } 
    public ICollection<TreatFlavor> Flavors { get; }
  }
}