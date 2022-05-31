using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IDeliverablesService
    {
        IEnumerable<DeliverableResponse> GetDeliverablesByProject(string projectId);
        DeliverableResponse AddDeliverable(DeliverableRequest delRequest);
        DeliverableResponse UpdateDeliverable(DeliverableRequest delRequest, string delId);
        void DeleteDeliverable(string delId);
    }
}
