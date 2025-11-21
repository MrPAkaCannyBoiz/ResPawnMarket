using System.Threading.Tasks;

namespace BlazorApp.Services;

public interface IAuthService
{
    Task<LoggedReseller> LoginAsync(string username, string password);
}