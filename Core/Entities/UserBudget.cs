using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("UserBudget")]
public partial class UserBudget
{
    [Key]
    public int UserBudgetId { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [StringLength(100)]
    public string ItemName { get; set; } = null!;

    [StringLength(500)]
    public string ItemDescription { get; set; } = null!;

    public DateTime BudgetDate { get; set; }

    public bool? RepeatEveryMonth { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserBudgets")]
    public virtual UserProfile? User { get; set; }
}
