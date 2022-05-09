using Domain.Dtos.Responses;

namespace Application.Interfaces.Util
{
    public interface IPDFService
    {
        Stream GenerateProjectCharter(ProjectResponse project);
    }
}
