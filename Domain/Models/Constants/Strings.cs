
using System.Reflection;

namespace Domain.Models.Constants
{
    public static class Strings
    {
        public const string FileContainerName = "wipipresources";

        public const string ManagerRole = "Manager";
        public const string LeadRole = "Lead";
        public const string AdminRole = "Admin";

        public const string UsersRoute = "users/";
        public const string UserRoute = "user/";
        public const string ManagersRoute = "managers/";
        public const string LoginRoute = "login/";
        public const string RegisterRoute = "register/";
        public const string ChangePasswordRoute = "changePassword/";

        public const string AssumptionCategory = "Assumptions Risks";
        public const string ProjectGoalsCategory = "Project goals Risks";
        public const string ResourceCategory = "Resource Risks";
        public const string PaymentCategory = "Payment Risks";
        public const string CommunicationCategory = "Communication Risks";
        public const string ScopeCategory = "Scope Risks";
        public const string BudgetCategory = "Budget Risks";



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
