
using System.Reflection;

namespace Domain.Models.Constants
{
    public static class Strings
    {
        public const string FileContainerName = "wipipresources";

        public const string ManagerRole = "Manager";
        public const string LeadRole = "Lead";

        public const string StakeholderRoute = "stakeholders/";
        public const string ProjectStakeholderRoute = "projectstakeholders/";
        public const string EmployeeRoute = "employees/";
        public const string CandidateRoute = "candidates/";

        public static string GetNullRefExcMethodParameterMessage(string parameter)
        {
            return $"No {parameter} sent to {MethodBase.GetCurrentMethod()?.Name} method";
        }
    }
}
