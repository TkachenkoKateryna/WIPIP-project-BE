
namespace Domain.Models.Dtos.Requests
{
    public class AssumptionRequest
    {
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
    }
}
