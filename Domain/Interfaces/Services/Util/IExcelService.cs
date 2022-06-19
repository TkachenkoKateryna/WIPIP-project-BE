
namespace Domain.Interfaces.Services.Util
{
    public interface IExcelService
    {
        byte[] GenerateRiskRegisterXml(Guid projectId);
        byte[] GenerateStakeholderRegisterXml(Guid projectId, string projectName);
    }
}
