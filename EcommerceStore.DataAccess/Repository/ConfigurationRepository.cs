using EcommerceStore.DataAccess.Data;
using EcommerceStore.DataAccess.Repository.IRepository;
using EcommerceStore.Model;
using Microsoft.Extensions.Configuration;

namespace EcommerceStore.DataAccess.Repository
{
    public class ConfigurationRepository : Repository<Configurations>, IConfigurationRepository
    {
        private ApplicationDbContext _db;
        public ConfigurationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Configurations obj)
        {
            _db.Update(obj);
        }
    }
}
