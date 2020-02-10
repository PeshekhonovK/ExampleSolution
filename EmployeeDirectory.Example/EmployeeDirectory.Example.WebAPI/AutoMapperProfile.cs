using AutoMapper;
using EmployeeDirectory.Example.Client.DTO.Create;
using EmployeeDirectory.Example.Client.DTO.Read;
using EmployeeDirectory.Example.Client.DTO.Update;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Employee, Domain.Employee>();
            this.CreateMap<DataAccess.Entities.Department, Domain.Department>();
            this.CreateMap<Domain.Employee, EmployeeDTO>();
            this.CreateMap<Domain.Department, DepartmentDTO>();
            this.CreateMap<EmployeeCreateDTO, EmployeeUpdateModel>();
            this.CreateMap<EmployeeUpdateDTO, EmployeeUpdateModel>();
        }
    }
}