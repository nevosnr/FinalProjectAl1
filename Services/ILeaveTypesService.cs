using FinalProjectAl1.Models.LeaveTypes;

namespace FinalProjectAl1.Services
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeExistsAsync(string leaveTypeName);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task Create(LeaveTypeCreateVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAllAsync();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
        Task Update(LeaveTypeEditVM model);
    }
}