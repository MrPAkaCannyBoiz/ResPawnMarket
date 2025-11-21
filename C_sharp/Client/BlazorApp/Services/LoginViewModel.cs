using BlazorApp.State;

namespace BlazorApp.Services;

public class LoginViewModel
{
    private readonly IAuthService authService;
    private readonly AuthState authState;

    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Error { get; private set; } = "";

    public LoginViewModel(IAuthService authService, AuthState authState)
    {
        this.authService = authService;
        this.authState = authState;
    }

    public async Task<bool> LoginAsync()
    {
        try
        {
            Error = "";
            var reseller = await authService.LoginAsync(Username, Password);
            authState.SetReseller(reseller);
            return true;
        }
        catch
        {
            Error = "Invalid username or password";
            return false;
        }
    }
}