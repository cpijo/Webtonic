using System.Collections.Generic;

namespace Webtonic.Models.Services.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        void SaveMany(List<T> model);
        void Delete(List<T> model);
    }
}