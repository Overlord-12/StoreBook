using AutoMapper;
using BuisnessObjects;
using StoreBookWebApi.Models.Employee;

namespace StoreBookWebApi
{
    public class StoreBookWebApiMapper:Profile
    {
        public StoreBookWebApiMapper()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
