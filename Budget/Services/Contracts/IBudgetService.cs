using Budget.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budget.Services.Contracts
{
    public interface IBudgetService
    {
        Task<LineItem> GetLineItemAsync(long id);
        Task<Day> GetDayAsync(DateTime date);
        Task<Month> GetMonthAsync(DateTime date);
        Task<List<Month>> GetYearsAsync(DateTime startDate, int numberOfYears = 1);
    }
}
