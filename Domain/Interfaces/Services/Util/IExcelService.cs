
namespace Domain.Interfaces.Services.Util
{
    public interface IExcelService
    {
        byte[] GenerateRiskRegisterXml(string projectId);
        byte[] GenerateStakeholderRegisterXml(string projectId, string projectName);
    }
}
