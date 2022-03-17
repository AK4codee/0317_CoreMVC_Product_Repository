namespace _0317_Product_Repository.Repositories.Interface
{
    public interface IProductRepository : IDBRepository
    {
        public void DeleteById(int id);
    }
}
