using EcommerceStore.DataAccess.Data;
using EcommerceStore.DataAccess.Repository.IRepository;
using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository
{
    public class WishListRepository:Repository<WishList>,IWishListRepository
    {
        private ApplicationDbContext _db;
        public WishListRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

    }
}
