using Inventory.Domain.Interfaces;

namespace Inventory.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public int Commit()
        {
            return _dbFactory.DbContext.SaveChanges();
        }
    }
}
