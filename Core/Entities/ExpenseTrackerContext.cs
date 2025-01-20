using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

public partial class ExpenseTrackerContext : DbContext
{
    public ExpenseTrackerContext()
    {
    }

    public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<EmailCopy> EmailCopies { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<FamilyMemberRequest> FamilyMemberRequests { get; set; }

    public virtual DbSet<UserBudget> UserBudgets { get; set; }

    public virtual DbSet<UserIncome> UserIncomes { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardId).HasName("PK_CreditCard_CreditCardId");

            entity.HasOne(d => d.User).WithMany(p => p.CreditCards).HasConstraintName("FK_CreditCard_UserProfile");
        });

        modelBuilder.Entity<EmailCopy>(entity =>
        {
            entity.HasKey(e => e.EmailCopyId).HasName("PK_EmailCopy_EmailCopyId");

            entity.Property(e => e.EmailFrom).HasDefaultValue("learnsmartcoding@gmail.com");
            entity.Property(e => e.SentDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK_Expense_ExpenseId");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_CreditCard");

            entity.HasOne(d => d.ExpenseCategory).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_Category");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_Type");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_User");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.HasKey(e => e.ExpenseCategoryId).HasName("PK_ExpenseCategory_ExpenseCategoryId");
        });

        modelBuilder.Entity<ExpenseItem>(entity =>
        {
            entity.HasKey(e => e.ExpenseItemId).HasName("PK_ExpenseItem_ExpenseId");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.ExpenseItems).HasConstraintName("FK_ExpenseItem_CreditCard");

            entity.HasOne(d => d.ExpenseCategory).WithMany(p => p.ExpenseItems).HasConstraintName("FK_ExpenseItem_Category");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpenseItems).HasConstraintName("FK_ExpenseItem_Expense");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.ExpenseItems).HasConstraintName("FK_ExpenseItem_Type");

            entity.HasOne(d => d.User).WithMany(p => p.ExpenseItems).HasConstraintName("FK_ExpenseItem_User");
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.HasKey(e => e.ExpenseTypeId).HasName("PK_ExpenseType_ExpenseTypeId");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK_Family_FamilyId");
        });

        modelBuilder.Entity<FamilyMemberRequest>(entity =>
        {
            entity.HasKey(e => e.FamilyMemberRequestId).HasName("PK_FamilyMemberRequest_FamilyMemberRequestId");

            entity.HasOne(d => d.RequestedUser).WithMany(p => p.FamilyMemberRequests).HasConstraintName("FK_FamilyMemberRequest_UserProfile");
        });

        modelBuilder.Entity<UserBudget>(entity =>
        {
            entity.HasKey(e => e.UserBudgetId).HasName("PK_UserBudget_UserBudgetId");

            entity.Property(e => e.BudgetDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.UserBudgets).HasConstraintName("FK_UserBudget_UserProfile");
        });

        modelBuilder.Entity<UserIncome>(entity =>
        {
            entity.HasKey(e => e.UserIncomeId).HasName("PK_UserIncome_UserIncomeId");

            entity.Property(e => e.IncomeDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.UserIncomes).HasConstraintName("FK_UserIncome_UserProfile");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserProfile_UserId");

            entity.Property(e => e.DisplayName).HasDefaultValue("Guest");

            entity.HasOne(d => d.Family).WithMany(p => p.UserProfiles).HasConstraintName("FK_UserProfile_Family");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
