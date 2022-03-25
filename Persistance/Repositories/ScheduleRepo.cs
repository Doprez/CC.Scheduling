using CC.Scheduling.Persistance.Interfaces;
using ServiceManager.Persistance.Data;

namespace CC.Scheduling.Persistance.Repositories;

public class ScheduleRepo : IScheduleRepo
{
    private readonly ServiceDbContext _context;
    public ScheduleRepo(ServiceDbContext context)
    {
        _context = context;
    }
}
