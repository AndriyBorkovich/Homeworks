using Microsoft.EntityFrameworkCore;

namespace HW_7_8.Models;

public class AccountingContext: DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public AccountingContext(DbContextOptions<AccountingContext> options): base(options)
    {
        
    }
}