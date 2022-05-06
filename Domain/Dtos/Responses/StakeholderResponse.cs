using Domain.Constants;
using Domain.Dtos.Base;

namespace Domain.Dtos.Responses
{
    public class StakeholderResponse : BaseResponse
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
