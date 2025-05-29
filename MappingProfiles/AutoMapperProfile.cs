using AutoMapper;
using FinalProjectAl1.Data;
using FinalProjectAl1.Models.LeaveTypes;

namespace FinalProjectAl1.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Direction is important when mapping!
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();

            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }
    }
}
