using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services.Util
{
    public interface IPDFService
    {
        Stream GenerateProjectCharter(ProjectResponse project);
    }
}
