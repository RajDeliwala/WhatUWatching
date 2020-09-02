using Show.Core.Models;
using System.Linq;

namespace Show.Core.Contracts
{
    public interface IRepo<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}