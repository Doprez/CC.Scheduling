using CC.Scheduling.API.Core.Date;
using CC.Scheduling.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CC.Scheduling.API.Controllers;

[ApiController]
[Route("api/Date")]
public class DateController : Controller
{
	private readonly DateCommands DateHandler = new();

	[HttpGet("DaysInMonthAndYear")]
	public async Task<IEnumerable<CustomDate>> GetDaysInMonthAndYear(int year, int month)
	{
		return await DateHandler.GetDaysInMonthAndYear(year, month);
	}
}
