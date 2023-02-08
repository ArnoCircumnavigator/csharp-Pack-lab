using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class GetDateListReply<TData> : BaseReply where TData : class
    {
        public IList<TData> DataList { get; set; }
    }
}
