using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW_7_8.Models;
//[PrimaryKey(nameof(Id), nameof(Name))]

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    public IEnumerable<Expense> Expenses { get; set; }
    public Category()
    {
        Expenses = new List<Expense>();
    }
}