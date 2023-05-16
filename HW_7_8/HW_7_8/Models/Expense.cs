using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HW_7_8.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_7_8;

public class Expense
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string? Title { get; set; }
    [Column(TypeName = "money")]
    public decimal Cost { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string? Comment { get; set; }

    public DateTime Date { get; set; }
    [ForeignKey("Category")] public int  CategoryId { get; set; }

    public Category? Category { get; set; }
}