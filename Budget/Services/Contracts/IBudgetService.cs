using Budget.Models;
using System;
using System.Threading.Tasks;

namespace Budget.Services.Contracts
{
    public interface IBudgetService
    {
        Task<Day> GetDayAsync(DateTime date);
        Task<Month> GetMonthAsync(DateTime date);
    }
}
