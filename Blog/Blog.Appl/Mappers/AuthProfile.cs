using AutoMapper;
using Blog.Appl.Request;
using Blog.Appl.Response;
using Blog.Domain.Entities;

namespace Blog.Appl.Mappers
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
