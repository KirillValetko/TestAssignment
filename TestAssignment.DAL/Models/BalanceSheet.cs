namespace TestAssignment.DAL.Models
{
    public class BalanceSheet
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string CompanyName { get; set; }
    }
}
