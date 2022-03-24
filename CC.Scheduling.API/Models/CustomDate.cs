namespace CC.Scheduling.API.Models;
public class CustomDate
{
	public int Day { get; set; }
	public int Month { get; set; }
	public int Year { get; set; }
	public string DayName { get; set; }
	public string MonthName { get; set; }
	public bool IsWeekend { get; set; }
}
