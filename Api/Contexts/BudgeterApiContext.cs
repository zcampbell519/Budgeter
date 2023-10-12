using Budgeter.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budgeter.Api.Contexts;
public class BudgeterApiContext:DbContext
{
    public DbSet<Account> Accounts {get;set;}=default!;
    public DbSet<Transaction> Transactions {get;set;} = default!;
    public DbSet<TransactionEntry> TransactionEntries {get;set;} = default!;

    public BudgeterApiContext(DbContextOptions<BudgeterApiContext> options):base(options){
        
    }
}