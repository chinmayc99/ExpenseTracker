using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

[Table("UserProfile")]
[Index("FamilyId", Name = "IDX_Expense_FamilyId")]
public partial class UserProfile
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string DisplayName { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(128)]
    public string AdObjId { get; set; } = null!;

    public int? FamilyId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    [InverseProperty("User")]
    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();

    [InverseProperty("User")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    [ForeignKey("FamilyId")]
    [InverseProperty("UserProfiles")]
    public virtual Family? Family { get; set; }

    [InverseProperty("RequestedUser")]
    public virtual ICollection<FamilyMemberRequest> FamilyMemberRequests { get; set; } = new List<FamilyMemberRequest>();

    [InverseProperty("User")]
    public virtual ICollection<UserBudget> UserBudgets { get; set; } = new List<UserBudget>();

    [InverseProperty("User")]
    public virtual ICollection<UserIncome> UserIncomes { get; set; } = new List<UserIncome>();
}
