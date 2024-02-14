using FluentValidation;

namespace Blog.Appl.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(post => post.Username).NotEmpty();
            RuleFor(post => post.Email).NotEmpty();
            RuleFor(post => post.Password).NotEmpty();
            RuleFor(post => post.Role).NotEmpty();
        }
    }
}
