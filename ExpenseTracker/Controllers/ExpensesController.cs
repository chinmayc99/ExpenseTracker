using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)

        {
            _expenseService = expenseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetExpenseByUserId(int userId)
        {
            var user = await _expenseService.GetExpenseByUserIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("family/{familyId}")]
        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes:Read")]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpensesByFamilyId(int familyId)
        {
            var expenses = await _expenseService.GetExpensesByFamilyIdAsync(familyId);
            return Ok(expenses);
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseModel expenseModel)
        {
            await _expenseService.AddExpenseAsync(expenseModel);
            return CreatedAtAction(nameof(GetExpenseById), new { id = expenseModel.ExpenseId }, expenseModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, ExpenseModel expenseModel)
        {
            if(id != expenseModel.ExpenseId)
            {
                return BadRequest();
            }
            await _expenseService.UpdateExpenseAsync(expenseModel);
            return Ok();
         }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return NoContent();
        }

        [HttpGet("types")]
        
        public async Task<IActionResult> GetAllExpenseTypes()
        {
            var expenseTypes = await _expenseService.GetAllExpenseTypesAsync();
            return Ok(expenseTypes);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllExpenseCategories()
        {
            var expenseCategories = await _expenseService.GetAllExpenseCategoriesAsync();
            return Ok(expenseCategories);
        }

        [HttpGet("creditcards")]
        public async Task<IActionResult> GetAllCreditCards()
        {
            var creditCards = await _expenseService.GetAllCreditCardsAsync();
            return Ok(creditCards);
        }


    }
}
