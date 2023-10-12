using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Budgeter.Api.Enums;

namespace Budgeter.Api.Entities;

public class TransactionEntry
{
    [Key]
    public int TransactionEntryId {get;set;}
    [ForeignKey("Account"), Required]
    public int AccountId { get; set; }
    [Required, NotNull]
    public Account Account { get; set; } = new();
    public TransactionType TransactionType { get; set; }
    [Required]
    public decimal TransactionAmount { get; set; }
    [Required, ForeignKey("Transaction")]
    public int TransactionId { get; set; }
    [NotNull, Required]
    public Transaction Transaction { get; set; } = new();
}