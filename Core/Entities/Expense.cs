using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("Expense")]
[Index("UserId", Name = "IDX_Expense_UserId")]
public partial class Expense
{
    [Key]
    public int ExpenseId { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal ExpenseAmount { get; set; }

    public int? ExpenseCategoryId { get; set; }

    public int? ExpenseTypeId { get; set; }

    public int? CreditCardId { get; set; }

    [StringLength(500)]
    public string ExpenseDescription { get; set; } = null!;

    public DateTime ExpenseDate { get; set; }

    [ForeignKey("CreditCardId")]
    [InverseProperty("Expenses")]
    public virtual CreditCard? CreditCard { get; set; }

    [ForeignKey("ExpenseCategoryId")]
    [InverseProperty("Expenses")]
    public virtual ExpenseCategory? ExpenseCategory { get; set; }

    [InverseProperty("Expense")]
    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

    [ForeignKey("ExpenseTypeId")]
    [InverseProperty("Expenses")]
    public virtual ExpenseType? ExpenseType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Expenses")]
    public virtual UserProfile? User { get; set; }
}
