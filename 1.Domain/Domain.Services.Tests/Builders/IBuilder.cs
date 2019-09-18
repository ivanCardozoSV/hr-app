namespace Domain.Services.Tests.Builders
{
    public interface IBuilder<T> where T : class
    {
        T Build();
    }
}
