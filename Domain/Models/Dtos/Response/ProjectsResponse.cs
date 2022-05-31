using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class ProjectsResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public ManagerResponse Manager { get; set; }
        public List<string> Stakeholders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
