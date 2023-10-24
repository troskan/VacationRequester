using Microsoft.EntityFrameworkCore;
using VacationRequester.Data;
using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly AppDbContext _context;

        public LeaveRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.LeaveRequests.Include(lt => lt.LeaveType)
                      .Where(lr => lr.UserId == userId)
                      .OrderBy(lr => lr.StartDate)
                      .ToListAsync();

        }
        
        public async Task<IEnumerable<LeaveRequest>> GetAllWithJoin()
        {
            return await _context.LeaveRequests
                .Include(lr => lr.User)
                .Include(lr => lr.LeaveType)
                .OrderBy(lr => lr.StartDate)
                .ToListAsync();


        }
    }
}
