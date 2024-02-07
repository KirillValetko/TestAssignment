namespace TestAssignment.DAL.Models
{
    public class BalanceSheetAccount
    {
        public int Id { get; set; }
        public decimal IncomingBalance { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int AccountId { get; set; }
        public int BalanceSheetId { get; set; }
    }
}
