namespace Domain.Models.Dtos.Responses
{
    public class DeliverableResponse
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfComplition { get; set; }
        public string ProjectId { get; set; }
    }
}
