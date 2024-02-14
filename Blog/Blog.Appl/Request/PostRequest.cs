using FluentValidation;

namespace Blog.Appl.Request
{
    public class PostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }

    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Content).NotEmpty();
            RuleFor(post => post.UserId).NotEmpty();
        }
    }
}
