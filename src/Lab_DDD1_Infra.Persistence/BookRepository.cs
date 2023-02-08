using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Repositories;
using Lab_DDD1_Infra.PersistenceModel;

namespace Lab_DDD1_Infra.Persistence
{
    public class BookRepository : Repository<Book, UniqueId>, IBookRepository
    {

    }
}