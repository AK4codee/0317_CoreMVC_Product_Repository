namespace _0317_Product_Repository.Repository.Interface
{
    public interface IShopRepository : IDBRepository
    {
        public void DeleteById(int id);
    }
}
