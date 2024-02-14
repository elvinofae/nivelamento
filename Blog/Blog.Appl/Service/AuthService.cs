using AutoMapper;
using Blog.Appl.Interfaces.Services;
using Blog.Appl.Request;
using Blog.Appl.Response;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositorys;

namespace Blog.Appl.Service
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public AuthService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return _mapper.Map<List<UserResponse>>(result);
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            return _mapper.Map<UserResponse>(result);
        }

        public async Task<UserResponse> GetByNameAsync(string username)
        {
            var result = await _repository.GetByParamAsync(p => p.Username == username);

            return _mapper.Map<UserResponse>(result);
        }

        public async Task<bool> AddAsync(UserRequest request)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                user.CreatedAt = DateTime.Now;

                await _repository.AddAsync(user);
                return true;
            }
            catch
            {
                //ToDo:logar
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, UserRequest request)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);

                user.Username = request.Username;
                user.Email = request.Email;
                user.Password = request.Password;

                await _repository.UpdateAsync(user);
                return true;
            }
            catch
            {
                //ToDo:logar erro
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                await _repository.DeleteAsync(user);
                return true;
            }
            catch
            {
                //ToDo:logar erro
                return false;
            }
        }
    }
}
