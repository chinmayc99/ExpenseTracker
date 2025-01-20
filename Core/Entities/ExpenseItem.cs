using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("ExpenseItem")]
public partial class ExpenseItem
{
    [Key]
    public int ExpenseItemId { get; set; }

    public int? ExpenseId { get; set; }

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
    [InverseProperty("ExpenseItems")]
    public virtual CreditCard? CreditCard { get; set; }

    [ForeignKey("ExpenseId")]
    [InverseProperty("ExpenseItems")]
    public virtual Expense? Expense { get; set; }

    [ForeignKey("ExpenseCategoryId")]
    [InverseProperty("ExpenseItems")]
    public virtual ExpenseCategory? ExpenseCategory { get; set; }

    [ForeignKey("ExpenseTypeId")]
    [InverseProperty("ExpenseItems")]
    public virtual ExpenseType? ExpenseType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ExpenseItems")]
    public virtual UserProfile? User { get; set; }
}
