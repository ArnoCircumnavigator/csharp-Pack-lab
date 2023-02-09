namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class UpdateEntityRequest<TEntityId> : BaseRequest
    {
        public TEntityId Id { get; set; }
    }
}
