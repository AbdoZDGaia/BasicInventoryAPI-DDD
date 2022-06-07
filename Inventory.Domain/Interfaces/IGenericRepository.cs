namespace Inventory.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);

        T GetById(int id);

        List<T> GetAll();

        IQueryable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
    }
}
