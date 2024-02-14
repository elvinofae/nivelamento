using Blog.Appl.Request;
using Blog.Appl.Response;

namespace Blog.Appl.Interfaces.Services
{
    public interface IPostService
    {
        Task<List<PostResponse>> GetAllAsync();
        Task<PostResponse> GetByIdAsync(int id);
        Task<PostResponse> GetByUserAsync(int userId);
        Task<string> GetDateTodayAsync();
        Task<bool> AddAsync(PostRequest entity);
        Task<bool> UpdateAsync(int id, PostRequest entity);
        Task<bool> DeleteAsync(int id);
    }
}
