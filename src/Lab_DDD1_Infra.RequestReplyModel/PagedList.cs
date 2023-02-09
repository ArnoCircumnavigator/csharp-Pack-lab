using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class PagedList<TData> : List<TData>, IPagedList<TData>
    {
        public PagedList(IEnumerable<TData> pageData, int totalCount, int pageIndex, int pageSize)
        {
            this.TotalCount = totalCount;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(pageData);
        }

        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage
        {
            get
            {
                int pageCount = TotalCount / PageSize;
                return TotalCount % PageSize == 0 ? pageCount : pageCount + 1;
            }
        }
    }
}
