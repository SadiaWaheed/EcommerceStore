using EcommerceStore.DataAccess.Data;
using EcommerceStore.DataAccess.Repository.IRepository;
using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private ApplicationDbContext _db;
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Genre obj)
        {
            _db.Update(obj);
        }
    }
}
