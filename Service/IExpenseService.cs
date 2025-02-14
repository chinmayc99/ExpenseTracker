﻿using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IExpenseService
    {
        Task<ExpenseModel> GetExpenseByIdAsync(int expenseId);

        Task<IEnumerable<ExpenseModel>> GetExpenseByUserIdAsync(int userId);

        Task<IEnumerable<ExpenseModel>> GetExpensesByFamilyIdAsync(int familyId);

        Task AddExpenseAsync(ExpenseModel expense);

        Task UpdateExpenseAsync(ExpenseModel expense);

        Task DeleteExpenseAsync(int expenseId);

        Task<IEnumerable<ExpenseTypeModel>> GetAllExpenseTypesAsync();
        Task<IEnumerable<ExpenseCategoryModel>> GetAllExpenseCategoriesAsync();
        Task<IEnumerable<CreditCardModel>> GetAllCreditCardsAsync();
    }
}
