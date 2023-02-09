using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Ioc;
using Lab_DDD1_Infra.PersistenceModel;

namespace Lab_DDD1_Infra.RequestReplyModel
{
    public abstract class BaseService
    {
        protected BaseReply ProcessRequest(Action requestHandler)
        {
            return ProcessRequest<BaseReply>(requestHandler);
        }
        protected TReply ProcessRequest<TReply>(Action requestHandler)
            where TReply : BaseReply, new()
        {
            var reply = new TReply();

            try
            {
                requestHandler();
                DependencyResolver.Resolve<IUnitOfWork>().SubmitChanges();
                reply.Success = true;
            }
            catch (DomainException ex)
            {
                reply.Success = false;
                reply.ErrorState.ErrorItems = ex.ValidationError.GetErrors().ToErrorItemList();
            }
            catch (Exception ex)
            {
                reply.Success = false;
                if (ex.InnerException != null && ex.InnerException is DomainException domainException)
                {
                    reply.ErrorState.ErrorItems = domainException.ValidationError.GetErrors().ToErrorItemList();
                }
                else
                {
                    reply.ErrorState.ExceptionMessage = ex.Message;
                }
            }

            return reply;
        }
    }
}
