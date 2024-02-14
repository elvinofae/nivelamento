namespace Blog.Appl.Interfaces
{
    public interface ITokenConfiguration
    {
        public string GenerateJwtToken(string username, string role);
    }
}
