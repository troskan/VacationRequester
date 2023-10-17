using VacationRequester.Models;

namespace VacationRequester.Repositories.Interfaces
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllByUserIdAsync(Guid userId);


    }
}
