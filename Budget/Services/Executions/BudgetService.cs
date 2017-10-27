using Budget.Models;
using Budget.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Services.Executions
{
    public class BudgetService : IBudgetService
    {
        public async Task<LineItem> GetLineItemAsync(long id)
        {
            return MockBudgetData.LineItems.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<LineItem> AddLineItemAsync(LineItem item)
        {
            MockBudgetData.LineItems.Add(item);
            return item;
        }

        public async Task<LineItem> EditLineItemAsync(LineItem item)
        {
            var xItem = MockBudgetData.LineItems.Where(x => x.Id == item.Id).FirstOrDefault();
            xItem.Amount = item.Amount;
            xItem.Date = item.Date;
            xItem.Description = item.Description;
            xItem.Expected = item.Expected;
            xItem.Name = item.Name;
            xItem.Notes = item.Notes;
            return xItem;
        }

        public async Task<LineItem> DeleteLineItemAsync(long id)
        {
            var ret = await GetLineItemAsync(id);
            MockBudgetData.LineItems.RemoveAll(x => x.Id == id);
            return ret;
        }

        public async Task<Day> GetDayAsync(DateTime date)
        {
            var items = MockBudgetData.LineItems;
            var day = new Day(date)
            {
                LineItems = items.Where(x => x.Date.Date == date.Date).ToList()
            };

            day.LineItems.AddRange(MockBudgetData.MonthlyLineItems.ToLineItems(date.Month, date.Year).Where(x => x.Date.Date == date.Date));

            return day;
        }

        public async Task<Month> GetMonthAsync(DateTime date)
        {
            var items = MockBudgetData.LineItems.Where(x => x.Date.Month == date.Month).ToList();
            items.AddRange(MockBudgetData.MonthlyLineItems.ToLineItems(date.Month, date.Year).Where(x => x.Date.Month == date.Month));
            var month = new Month(date, items);
            return month;
        }

        public async Task<List<Month>> GetYearsAsync(DateTime startDate, int numberOfYears = 1)
        {
            List<Month> months = new List<Month>();
            for (var i = 0; i < numberOfYears * 12; i++)
            {
                months.Add(await GetMonthAsync(startDate));
                startDate = startDate.AddMonths(1);
            }
            return months;
        }

        public static class MockBudgetData
        {
            public static LineItem LineItem;
            public static List<LineItem> LineItems;
            public static MonthlyRepeatingLineItemList MonthlyLineItems;

            static MockBudgetData()
            {
                BuildLineItems();
                BuildMonthlyLineItems();
                LineItem = new LineItem
                {
                    Id = 1,
                    Date = DateTime.Today,
                    Description = $"Description for Single Line Item.",
                    Name = $"Single Line Item",
                    Notes = $"Notes for Single Line Item.",
                    Amount = 666
                };
                LineItems.Add(LineItem);
            }

            private static void BuildMonthlyLineItems()
            {
                MonthlyLineItems = new MonthlyRepeatingLineItemList();
                var random = new Random();
                for (var i = 0; i < 10; i++)
                {
                    MonthlyLineItems.Add(new MonthlyRepeatingLineItem
                    {
                        RID = i,
                        Description = $"Description for Monthly Recurring Line Item {i}.",
                        Name = $"Monthly Recurring Line Item {i}",
                        Notes = $"Notes for Monthly Recurring Line Item {i}.",
                        Amount = random.NextDouble() * 100,
                        DayOfMonth = (int)Math.Round((random.NextDouble()  * 31), 0)
                    });
                }
                MonthlyLineItems.Add(new MonthlyRepeatingLineItem
                {
                    RID = 11,
                    Description = $"Description for Monthly Recurring Line Item 11.",
                    Name = $"Monthly Recurring Line Item 11",
                    Notes = $"Notes for Monthly Recurring Line Item 11.",
                    Amount = random.NextDouble() * 100,
                    DayOfMonth = 31
                });
            }

            private static void BuildLineItems()
            {

                LineItems = new List<LineItem>();

                var random = new Random();
                for (var i = 1; i <= 12; i++)
                {
                    for (var j = 0; j < 25; j++)
                    {
                        try
                        {
                            var y = DateTime.Now.Year;
                            var m = i;
                            var d = 1 + (int)Math.Round((random.NextDouble() * 27), 0);
                            var dt = new DateTime(y, m, d);
                            LineItems.Add(new LineItem
                            {
                                Id = (i * 25) + j,
                                Date = dt,
                                Description = $"Description for Line Item {(i * 25) + j}.",
                                Name = $"Line Item {(i * 25) + j}",
                                Notes = $"Notes for Line Item {(i * 25) + j}.",
                                Amount = random.NextDouble() * 100
                            });
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
