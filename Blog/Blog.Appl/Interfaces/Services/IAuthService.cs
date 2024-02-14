using Blog.Appl.Request;
using Blog.Appl.Response;

namespace Blog.Appl.Interfaces.Services
{
    public interface IAuthService
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> GetByNameAsync(string username);
        Task<bool> AddAsync(UserRequest request);
        Task<bool> UpdateAsync(int id, UserRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
