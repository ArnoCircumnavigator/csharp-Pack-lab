using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Repositories;
using Lab_DDD1_Infra.PersistenceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.Persistence
{
    public class BorrowInfoRepository : Repository<BorrowInfo, UniqueId>, IBorrowInfoRepository
    {
        public bool FindNotReturnedBorrowInfos(UniqueId borrowerId, out IList<BorrowInfo> infos)
        {
            infos = GetAll().Where(borrowInfo => borrowInfo.Borrower.Id == borrowerId && borrowInfo.ReturnTime == null).ToList();
            return infos != null;
        }
        public bool FindNotReturnedBorrowInfo(UniqueId borrowerId, UniqueId bookId, out BorrowInfo info)
        {
            info = null;
            IEnumerable<BorrowInfo> ienumerable = GetAll();
            foreach (var borrowInfo in ienumerable)
            {
                if (borrowInfo.Borrower.Id == borrowerId
                    &&
                    borrowInfo.Book.Id == bookId
                    && 
                    borrowInfo.ReturnTime == null)
                {
                    info = borrowInfo;
                    break;
                }
            }
            return info != null;
        }
    }
}
