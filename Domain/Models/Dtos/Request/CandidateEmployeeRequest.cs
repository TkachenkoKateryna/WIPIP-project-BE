namespace Domain.Models.Dtos.Request
{
    public class CandidateEmployeeRequest
    {
        public string CandidateId { get; set; }
        public string EmployeeId { get; set; }
        public bool ToRemove { get; set; }
    }
}
