using System;
using System.Threading.Tasks;

namespace Core.Persistance
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
