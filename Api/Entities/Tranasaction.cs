using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Budgeter.Api.Entities;
public class Transaction
{
    [Key]
    public int TransactionId { get; set; }
    [Required]
    public DateTime TransactionDate { get; set; }
    [Required,NotNull]
    public string TransactionDescription { get; set; }=string.Empty;
    public virtual List<Transaction> TransactionEntries { get; set; } = new();
}