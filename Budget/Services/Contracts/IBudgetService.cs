using Budget.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budget.Services.Contracts
{
    public interface IBudgetService
    {
        /// <summary>
        /// Gets a single Line Item based on ID
        /// </summary>
        /// <param name="id">The ID of the line Item to get</param>
        /// <returns>Line Item</returns>
        Task<LineItem> GetLineItemAsync(long id);

        /// <summary>
        /// Adds a single Line Item
        /// </summary>
        /// <param name="item">The line Item to Add.</param>
        /// <returns>The line item</returns>
        Task<LineItem> AddLineItemAsync(LineItem item);

        /// <summary>
        /// Edit a single Line Item, by ID
        /// </summary>
        /// <param name="item">An edited copy of the existing item. The ID cannot be edited</param>
        /// <returns>The edited item</returns>
        Task<LineItem> EditLineItemAsync(LineItem item);

        /// <summary>
        /// Removes an item.
        /// </summary>
        /// <param name="id">The ID of the item to remove</param>
        /// <returns>A copy of the removed item</returns>
        Task<LineItem> DeleteLineItemAsync(long id);

        /// <summary>
        /// Gets a Day object, which conatins all of the line items for that day.
        /// </summary>
        /// <param name="date">The date of the object to return</param>
        /// <returns>Day</returns>
        Task<Day> GetDayAsync(DateTime date);

        /// <summary>
        /// Gets a Month Object, which contains all of the Day objects within that month.
        /// </summary>
        /// <param name="date">A date which contains the expected month and year</param>
        /// <returns>Month</returns>
        Task<Month> GetMonthAsync(DateTime date);

        /// <summary>
        /// Gets a colection of Month Objects, which contains all of the Month objects within the number of years specified.
        /// </summary>
        /// <param name="startDate">A date which contains the month and year in which to begin aggregating Months</param>
        /// <param name="numberOfYears">Number of Years to collect (Default is 1)</param>
        /// <returns>A Collection of Months</returns>
        Task<List<Month>> GetYearsAsync(DateTime startDate, int numberOfYears = 1);
    }
}
