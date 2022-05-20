using ClosedXML.Excel;

namespace Application.Interfaces.Util
{
    public interface IExcelService
    {
        byte[] GenerateRiskRegisterXml(string projectId);
    }
}
