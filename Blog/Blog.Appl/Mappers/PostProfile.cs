using AutoMapper;
using Blog.Appl.Request;
using Blog.Appl.Response;
using Blog.Domain.Entities;

namespace Blog.Appl.Mappers
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostResponse>();
        }
    }
}
