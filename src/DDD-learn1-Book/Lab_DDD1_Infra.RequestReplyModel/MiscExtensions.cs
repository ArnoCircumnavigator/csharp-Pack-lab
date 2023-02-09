using Lab_DDD1_Domain.CoreFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public static class MiscExtensions
    {
        public static List<ErrorItem> ToErrorItemList(this IEnumerable<ValidationErrorItem> validationErrorItems)
        {
            List<ErrorItem> items = new List<ErrorItem>();
            foreach (ValidationErrorItem item in validationErrorItems)
            {
                items.Add(new ErrorItem
                {
                    Key = item.ErrorKey,
                    Parameters = item.Parameters
                });
            }
            return items;
        }
    }
}
