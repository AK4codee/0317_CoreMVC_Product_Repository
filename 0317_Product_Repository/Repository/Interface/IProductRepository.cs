namespace _0317_Product_Repository.Repository.Interface
{
    public interface IProductRepository : IDBRepository
    {
        public void DeleteById(int id);
    }
}
