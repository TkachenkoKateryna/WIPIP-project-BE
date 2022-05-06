using Domain.Constants;
using Domain.Dtos.Base;

namespace Domain.Dtos.Responses
{
    public class ObjectiveResponse : BaseResponse
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
    }
}
