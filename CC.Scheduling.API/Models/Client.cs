namespace CC.Scheduling.Models;

public class Client
{
	public Guid ClientId { get; set; } = Guid.NewGuid();
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
}
