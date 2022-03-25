using CC.Scheduling.API.Models;

namespace CC.Scheduling.Models;

public class Schedule
{
	public Guid ScheduleId { get; set; } = Guid.NewGuid();
	public string Name { get; set; }
	public DateTime FromTime { get; set; }
	public DateTime ToTime { get; set; }
	public Client Client { get; set; }
}
