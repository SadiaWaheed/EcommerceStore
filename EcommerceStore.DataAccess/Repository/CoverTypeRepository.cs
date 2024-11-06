using EcommerceStore.DataAccess.Data;
using EcommerceStore.DataAccess.Repository.IRepository;
using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db):base(db)    
        {
            _db = db;
        }
    
        public void Update(CoverType obj)
        {
            _db.Update(obj);
        }

    }
}
