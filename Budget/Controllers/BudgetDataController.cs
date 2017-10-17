using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budget.Services.Contracts;
using Budget.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Budget.Controllers
{
    [Route("api/data")]
    public class BudgetDataController : Controller
    {
        private IBudgetService _budgetService;

        public BudgetDataController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("line")]
        public async Task<AbstractLineItem> GetLine(long id)
        {
            return await _budgetService.GetLineItemAsync(id);
        }

        [HttpPut("line")]
        public async Task<LineItem> AddLine(LineItem item)
        {
            return await _budgetService.GetLineItemAsync(1);
        }

        [HttpDelete("line")]
        public async Task<LineItem> DeleteLine(long id)
        {
            return await _budgetService.GetLineItemAsync(id);
        }

        [HttpGet("day")]
        public async Task<Day> GetDay(DateTime date)
        {
            return await _budgetService.GetDayAsync(date);
        }

        [HttpGet("month")]
        public async Task<Month> GetMonth(DateTime date)
        {
            return await _budgetService.GetMonthAsync(date);
        }

        [HttpGet("year")]
        public async Task<List<Month>> GetYear(DateTime date)
        {
            return await _budgetService.GetYearsAsync(date);
        }

    }
}
