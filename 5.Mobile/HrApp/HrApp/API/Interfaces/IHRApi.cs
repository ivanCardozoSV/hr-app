namespace HrApp.API.Interfaces
{
    public interface IHRApi
    {
        string Execute(HttpCommand httpCommand);
        void Setup(string user, string password);
    }
}