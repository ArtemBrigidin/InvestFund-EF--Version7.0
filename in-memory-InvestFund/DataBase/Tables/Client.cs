using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace in_memory_InvestFund.DataBase.Tables
{
    [PrimaryKey(nameof(ClientId))]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? BirthDay { get; set; }

        public int Amount { get; set; }
    }
}
