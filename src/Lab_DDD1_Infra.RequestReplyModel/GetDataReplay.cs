using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class GetDataReplay<TData> : BaseReply where TData : class
    {
        public TData Data { get; set; }
    }
}
