using ClosedXML.Excel;

namespace Domain.Interfaces.Services.Util
{
    public interface IExcelService
    {
        byte[] GenerateRiskRegisterXml(string projectId);
    }
}
