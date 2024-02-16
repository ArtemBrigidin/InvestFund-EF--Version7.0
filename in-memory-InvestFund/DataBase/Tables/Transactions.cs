using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace in_memory_InvestFund.DataBase.Tables
{
    [PrimaryKey(nameof(TransactionId))]
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        public int ClientId {get; set;}
        public int InvestmentId { get; set; }
        public string? InvestmentType { get; set; } 
        public string? TransactionDate { get; set; }
        public int TransactionAmount { get; set; }
    }
}
