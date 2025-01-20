using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseTrackerContext _dbContext;

        public ExpenseRepository(ExpenseTrackerContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
            var expense = await _dbContext.Expenses.FindAsync(expenseId);
            if (expense != null)
            {
                _dbContext.Expenses.Remove(expense);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CreditCard>> GetAllCreditCardsAsync()
        {
            return await _dbContext.CreditCards.ToListAsync();
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllExpenseCategoriesAsync()
        {
            return await _dbContext.ExpenseCategories.ToListAsync();
        }

        public async Task<IEnumerable<ExpenseType>> GetAllExpenseTypesAsync()
        {
            return await _dbContext.ExpenseTypes.ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int expenseId)
        {
            return await _dbContext.Expenses.FindAsync(expenseId);
        }

        public async Task<IEnumerable<Expense>> GetExpenseByUserIdAsync(int userId)
        {
            return await _dbContext.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByFamilyIdAsync(int familyId)
        {
            var userIds = await _dbContext.UserProfiles
                 .Where(u => u.FamilyId == familyId)
                 .Select(u => u.UserId)
                 .ToListAsync();

            return await _dbContext.Expenses
                .Where(e => userIds.Contains(e.UserId ?? 0))
                .ToListAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
            await _dbContext.SaveChangesAsync();
        }
    }
}
