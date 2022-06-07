using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
