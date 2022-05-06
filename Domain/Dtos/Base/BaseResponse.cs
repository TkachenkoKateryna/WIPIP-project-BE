namespace Domain.Dtos.Base
{
    public class BaseResponse
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
