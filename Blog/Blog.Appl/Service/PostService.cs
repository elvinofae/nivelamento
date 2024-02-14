using AutoMapper;
using Blog.Appl.Interfaces.Services;
using Blog.Appl.Request;
using Blog.Appl.Response;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositorys;

namespace Blog.Appl.Service
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PostResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return _mapper.Map<List<PostResponse>>(result);
        }

        public async Task<PostResponse> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            return _mapper.Map<PostResponse>(result);
        }

        public async Task<PostResponse> GetByUserAsync(int userId)
        {
            var result = await _repository.GetByParamAsync(p => p.UserId == userId);

            return _mapper.Map<PostResponse>(result);
        }

        public async Task<string> GetDateTodayAsync()
        {
            var result = await _repository.GetByParamAsync(p => p.CreatedAt.Date == DateTime.Today);

            return result.Title;
        }

        public async Task<bool> AddAsync(PostRequest request)
        {
            try
            {
                var user = _mapper.Map<Post>(request);
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

        public async Task<bool> UpdateAsync(int id, PostRequest request)
        {
            try
            {
                var post = await _repository.GetByIdAsync(id);

                post.Title = request.Title;
                post.Content = request.Content;

                await _repository.UpdateAsync(post);
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
                var post = await _repository.GetByIdAsync(id);
                await _repository.DeleteAsync(post);
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
