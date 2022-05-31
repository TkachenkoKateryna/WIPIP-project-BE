
namespace Domain.Models.Dtos.Responses
{
    public class AssumptionResponse
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
    }
}
