using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("ExpenseType")]
public partial class ExpenseType
{
    [Key]
    public int ExpenseTypeId { get; set; }

    [StringLength(50)]
    public string ExpenseTypeName { get; set; } = null!;

    [InverseProperty("ExpenseType")]
    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

    [InverseProperty("ExpenseType")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
