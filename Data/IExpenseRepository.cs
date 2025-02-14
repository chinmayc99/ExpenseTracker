﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseByIdAsync(int expenseId);

        Task<IEnumerable<Expense>> GetExpenseByUserIdAsync(int userId);

        Task<IEnumerable<Expense>> GetExpensesByFamilyIdAsync(int familyId);

        Task AddExpenseAsync(Expense expense);

        Task UpdateExpenseAsync(Expense expense);

        Task DeleteExpenseAsync(int expenseId);

        Task<IEnumerable<ExpenseType>> GetAllExpenseTypesAsync();
        Task<IEnumerable<ExpenseCategory>> GetAllExpenseCategoriesAsync();
        Task<IEnumerable<CreditCard>> GetAllCreditCardsAsync();

    }
}
