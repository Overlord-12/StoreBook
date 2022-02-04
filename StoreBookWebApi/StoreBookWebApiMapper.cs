using AutoMapper;
using BuisnessObjects;
using StoreBookWebApi.Models.Employee;
using StoreBookWebApi.Models.Register;

namespace StoreBookWebApi
{
    public class StoreBookWebApiMapper:Profile
    {
        public StoreBookWebApiMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<RegisterDto, User>();   
        }
    }
}
