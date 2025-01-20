using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("UserIncome")]
public partial class UserIncome
{
    [Key]
    public int UserIncomeId { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [StringLength(500)]
    public string IncomeDescription { get; set; } = null!;

    public DateTime IncomeDate { get; set; }

    public bool? RepeatEveryMonth { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserIncomes")]
    public virtual UserProfile? User { get; set; }
}
