using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class DeleteEntityRequest<TEntityId> : BaseRequest
    {
        public TEntityId Id { get; set; }
    }
}
