using BlazorApp1_Site.Models;

namespace BlazorApp1_Site.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResult> SignInAsync(string username, string password);
        Task<string> GetIdToken(string code);
    }
}
