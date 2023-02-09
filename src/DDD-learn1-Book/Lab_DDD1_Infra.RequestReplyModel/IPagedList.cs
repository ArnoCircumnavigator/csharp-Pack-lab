using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public interface IPagedList<TData> : IList<TData>
    {
        int TotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalPage { get; }
    }
}
