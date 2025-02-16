using AutoMapper;
using Demo.Data.Access.Layer.Models;
using Demo.Presentation.Layer.ViewModels;

namespace Demo.Presentation.Layer.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
    }
}

