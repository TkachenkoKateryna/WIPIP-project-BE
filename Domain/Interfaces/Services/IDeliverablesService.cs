using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IDeliverablesService
    {
        IEnumerable<DeliverableResponse> GetDeliverablesByProject(Guid projectId);
        DeliverableResponse AddDeliverable(DeliverableRequest delRequest);
        DeliverableResponse UpdateDeliverable(DeliverableRequest delRequest, Guid delId);
        void DeleteDeliverable(Guid delId);
    }
}
