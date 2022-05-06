using Domain.Constants;
using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class ObjectiveRequest : BaseRequest
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
    }
}
