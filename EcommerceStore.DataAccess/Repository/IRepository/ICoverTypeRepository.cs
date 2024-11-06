using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository:IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
