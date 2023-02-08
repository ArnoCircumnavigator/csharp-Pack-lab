using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;

namespace Lab_DDD1_Domain.Repositories
{
    public interface IBorrowInfoRepository :
        IRepository<BorrowInfo, UniqueId>,
        IRemoveableRepository<BorrowInfo, UniqueId>
    {
        bool FindNotReturnedBorrowInfos(UniqueId borrowerId, out IList<BorrowInfo> borrowInfos);
        bool FindNotReturnedBorrowInfo(UniqueId borrowerId, UniqueId bookId, out BorrowInfo borrowInfo);
    }
}
