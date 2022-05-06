using Domain.Constants;
using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class StakeholderRequest : BaseRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public Payment Payment { get; set; }

        public Engagement Engagement { get; set; }

        public StakeholderClass Class { get; set; }
    }
}
