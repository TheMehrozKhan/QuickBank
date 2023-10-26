using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCrudOperationsApp.Models
{
    public class BankTransactions
    {
        [Key]
        [Required]
        public int TransactionId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(12)")]
        public string AccountNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BeneficiaryName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BankName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string SWIFTCode { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }

    }
}
