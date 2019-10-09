namespace HrApp.Services.Interfaces
{
    public interface ILoginService
    {
        string Authenticate(string userName, string password);
        string AuthenticateExternal(string tkn);
    }
}