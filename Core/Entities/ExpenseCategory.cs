using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("ExpenseCategory")]
public partial class ExpenseCategory
{
    [Key]
    public int ExpenseCategoryId { get; set; }

    [StringLength(50)]
    public string ExpenseCategoryName { get; set; } = null!;

    [InverseProperty("ExpenseCategory")]
    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

    [InverseProperty("ExpenseCategory")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
