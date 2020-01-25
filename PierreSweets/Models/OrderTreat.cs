namespace PierreSweets.Models
{
    public class OrderTreat
    {
        public int OrderTreatId { get; set; }
        public int TreatId { get; set; }
        public int OrderId { get; set; }
        public Treat Treat { get; set; }
        public Order Order { get; set; }
    }
}