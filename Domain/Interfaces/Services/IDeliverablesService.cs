using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IDeliverablesService
    {
        IEnumerable<DeliverableResponse> GetAllDeliverables();
        DeliverableResponse AddDeliverable(DeliverableRequest delRequest);
        DeliverableResponse UpdateDeliverable(DeliverableRequest delRequest, string delId);
        void DeleteDeliverable(string delId);
    }
}
