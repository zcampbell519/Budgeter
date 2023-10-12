using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Budgeter.Api.Enums;

namespace Budgeter.Api.Entities;
public class Account
{
    [Key]
    public int AccountId { get; set; }
    [Required]
    public int AccountNumber {get;set;}
    [Required, MaxLength(50), NotNull]
    public string AccountName { get; set; } = string.Empty;
    [Required]
    public AccountType AccountType { get; set; }
    public bool IsContra { get; set; }

    public virtual List<TransactionEntry> TransactionEntries{get;set;}=new();
}