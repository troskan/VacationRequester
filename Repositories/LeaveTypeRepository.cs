using Microsoft.EntityFrameworkCore;
using VacationRequester.Data;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Repositories;
public class LeaveTypeRepository : Repository<LeaveTypeRepository>
{
    private readonly AppDbContext _context;

    public LeaveTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}