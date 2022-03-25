using CC.Scheduling.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CC.Scheduling.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SchedulingController : ControllerBase
{
	[HttpGet]
	public async Task GetSchedulesForDate()
	{
		return;
	}

}
