namespace Lab_DDD1_Infra.RequestReplyModel
{
    public class BaseReply
    {
        public BaseReply()
        {
            Success = true;
            ErrorState = new ErrorState();
        }
        public bool Success { get; set; }
        public ErrorState ErrorState { get; set; }
    }
}