using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace in_memory_InvestFund.DataBase.Tables
{
    [PrimaryKey(nameof(InvestmentId))]
    public class Investments
    {
        [Key]
        public int InvestmentId {  get; set; }
        public int ClientId {  get; set; }
        public string? InvestmentType { get; set; }
        public int InvestmentAmount {  get; set; }
        public string? PurchaseDate {  get; set; }
        public bool IsBuy { get; set; }
    }
}
