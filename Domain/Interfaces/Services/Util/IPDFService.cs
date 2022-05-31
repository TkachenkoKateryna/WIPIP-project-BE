using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services.Util
{
    public interface IPDFService
    {
        Stream GenerateProjectCharter(ProjectResponse project);
    }
}
