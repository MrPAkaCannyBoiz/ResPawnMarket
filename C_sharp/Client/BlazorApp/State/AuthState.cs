namespace BlazorApp.State;

public class AuthState
{
    public LoggedReseller? CurrentReseller { get; private set; }

    public bool IsLoggedIn => CurrentReseller != null;

    public void SetReseller(LoggedReseller reseller)
    {
        CurrentReseller = reseller;
    }

    public void Logout()
    {
        CurrentReseller = null;
    }
}