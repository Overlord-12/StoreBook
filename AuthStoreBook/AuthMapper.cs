using AuthStoreBook.Models;
using AutoMapper;
using BusinessObjects;

namespace StoreBookWebApi
{
    public class AuthMapper:Profile
    {
        public AuthMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();  
        }
    }
}
