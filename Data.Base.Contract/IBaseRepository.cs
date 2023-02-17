namespace Data.Base.Contract
{
    public interface IBaseRepository<TEntity>
        where TEntity : IEntityBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int? id);
        Task Insert(TEntity carEntity);
        Task Update(TEntity carEntity);
        Task Delete(int? id);
    }
}