using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    [Serializable]
    public class ErrorState
    {
        public ErrorState()
        {
            ErrorItems = new List<ErrorItem>();
        }
        public List<ErrorItem> ErrorItems { get; set; }
        public string ExceptionMessage { get; set; } = string.Empty;
    }
    [Serializable]
    public class ErrorItem
    {
        public ErrorItem()
        {
            Parameters = new List<object>();
        }
        public string Key { get; set; } = string.Empty;
        public List<object> Parameters { get; set; }
    }
}
