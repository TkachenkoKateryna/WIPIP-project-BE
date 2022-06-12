
using System.Reflection;

namespace Domain.Models.Constants
{
    public static class Strings
    {
        public const string FileContainerName = "wipipresources";

        public const string ManagerRole = "Manager";
        public const string LeadRole = "Lead";
        public const string AdminRole = "Admin";

        public const string StakeholderRoute = "stakeholders/";


        public const string EmployeeRoute = "employees/";
        public const string CandidateRoute = "candidates/";
        public const string CandidateEmployeeRoute = "candidates/employees";





        public const string UsersRoute = "users/";
        public const string UserRoute = "user/";
        public const string ManagersRoute = "managers/";
        public const string LoginRoute = "login/";
        public const string RegisterRoute = "register/";
        public const string ChangePasswordRoute = "changePassword/";

        public static string GetNullRefExcMethodParameterMessage(string parameter)
        {
            return $"No {parameter} sent to {MethodBase.GetCurrentMethod()?.Name} method";
        }

        public static string GetProjectRisksRoute(string projectId, string riskId)
        {
            return $"projects/{projectId}/risks/{riskId}";
        }
    }
}
