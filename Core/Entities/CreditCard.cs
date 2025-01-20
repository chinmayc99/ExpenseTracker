using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("CreditCard")]
public partial class CreditCard
{
    [Key]
    public int CreditCardId { get; set; }

    [StringLength(4)]
    public string CardLastFourDigit { get; set; } = null!;

    [StringLength(50)]
    public string CreditCardName { get; set; } = null!;

    public int? UserId { get; set; }

    [InverseProperty("CreditCard")]
    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

    [InverseProperty("CreditCard")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    [ForeignKey("UserId")]
    [InverseProperty("CreditCards")]
    public virtual UserProfile? User { get; set; }
}
