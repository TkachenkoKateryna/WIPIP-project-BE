namespace Domain.Models.Filters
{
    public class StakeholderFiteringParam
    {
        public string SearchBy { get; set; } = "";
        public Guid[] ProjectIds { get; set; }
    }
}
