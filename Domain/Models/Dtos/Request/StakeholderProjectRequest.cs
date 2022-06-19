namespace Domain.Models.Dtos.Stakeholder
{
    public class StakeholderProjectRequest
    {
        public Guid StakeholderId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
