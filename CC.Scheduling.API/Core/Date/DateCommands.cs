using CC.Scheduling.API.Models;
using CC.Scheduling.API.Models.Enumerations;

namespace CC.Scheduling.API.Core.Date;

public class DateCommands
{
	public async Task<IEnumerable<CustomDate>> GetDaysInMonthAndYear(int year, int month)
	{
		int numberOfDays = DateTime.DaysInMonth(year, month);
		var beginningDate = DateTime.Now.AddDays(-DateTime.Now.Day + 1);// getting the first day of the month
		beginningDate = beginningDate.AddMonths(-beginningDate.Month + month);// getting the first month of the year
		beginningDate = beginningDate.AddYears(-beginningDate.Year + year);

		var dateResult = new List<CustomDate>();

		for (int i = 0; i < numberOfDays; i++)
		{
			dateResult.Add(new CustomDate
			{
				Day = beginningDate.Day,
				Month = beginningDate.Month,
				Year = beginningDate.Year,
				DayName = beginningDate.DayOfWeek.ToString(),
				MonthName = GetMonthName(beginningDate.Month),
				IsWeekend = (beginningDate.DayOfWeek.ToString() == "Saturday" || beginningDate.DayOfWeek.ToString() == "Sunday"),

			});

			beginningDate = beginningDate.AddDays(1);
		}
		
		return await Task.FromResult(dateResult);

	}

	public string GetMonthName(int month)
	{
		MonthName monthName = (MonthName)month;

		return monthName.ToString();
	}
}
