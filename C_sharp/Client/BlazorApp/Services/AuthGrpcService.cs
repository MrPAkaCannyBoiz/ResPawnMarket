using Grpc.Net.Client;
using com.respawnmarket;

namespace BlazorApp.Services;

public class AuthGrpcService : IAuthService
{
    private readonly LoginResellerServiceGrpc.LoginResellerServiceGrpcClient client;

    public AuthGrpcService()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:6767");
        client = new LoginResellerServiceGrpc.LoginResellerServiceGrpcClient(channel);
    }

    public async Task<LoggedReseller> LoginAsync(string username, string password)
    {
        var request = new LoginResellerRequest
        {
            Username = username,
            Password = password
        };

        var response = await client.LoginResellerAsync(request);

        return new LoggedReseller
        {
            Id = response.Id,
            Username = response.Username
        };
    }
}