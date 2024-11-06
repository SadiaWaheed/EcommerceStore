using EcommerceStore.Model;

namespace EcommerceStore.DataAccess.Repository.IRepository
{
    public interface IGenreRepository :IRepository<Genre>
    {
        void Update(Genre obj);
    }
}
