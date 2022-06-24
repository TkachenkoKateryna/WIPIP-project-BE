namespace Domain.Models.Dtos.Request
{
    public class CandidateEmployeeRequest
    {
        public Guid CandidateId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public bool ToRemove { get; set; }
    }
}
