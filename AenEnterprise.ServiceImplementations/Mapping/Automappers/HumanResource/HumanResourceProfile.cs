using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.HumanResource
{
    public class HumanResourceProfile:Profile
    {
        public HumanResourceProfile()
        {
            CreateMap<Employee, EmployeeView>();
            CreateMap<Attendance, AttendanceView>()
           .ForMember(dest => dest.WorkingHours, opt => opt.MapFrom(src => src.WorkingHours))
           .ForMember(dest => dest.OvertimeHours, opt => opt.MapFrom(src => src.OverTimeHours))
           .ForMember(dest => dest.RegularHours, opt => opt.MapFrom(src => src.RegularHours));
        }

    }
    
}

