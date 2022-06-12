namespace Domain.Models.Filters
{
    public class ProjectFilteringParams
    {
        public string SearchBy { get; set; } = "";
        public string[] UsersIds { get; set; }
    }
}
