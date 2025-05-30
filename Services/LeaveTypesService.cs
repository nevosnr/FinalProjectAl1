using AutoMapper;
using FinalProjectAl1.Data;
using FinalProjectAl1.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAl1.Services;

public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
{


    public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        var data = await _context.LeaveTypes.ToListAsync();

        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        return viewData;
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);

        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.LeaveTypeId == id);

        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.LeaveTypeId == id);

        if (data == null) { return null; }

        var viewData = _mapper.Map<T>(data);

        return viewData;
    }


    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.LeaveTypeId == id);
    }
    public async Task<bool> CheckIfLeaveTypeExistsAsync(string leaveTypeName)
    {
        var lowerCaseName = leaveTypeName.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.LeaveTypeName.ToLower().Equals(leaveTypeName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowerCaseName = leaveTypeEdit.LeaveTypeName.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.LeaveTypeName.ToLower().Equals(lowerCaseName)
        && q.LeaveTypeId != leaveTypeEdit.LeaveTypeId);
    }



}
