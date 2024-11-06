using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository.IRepository
{
    public interface IConfigurationRepository:IRepository<Configurations>
    {
        void Update(Configurations obj);
    }
}
