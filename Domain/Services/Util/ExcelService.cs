using ClosedXML.Excel;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.OpenApi.Extensions;

namespace Domain.Services.Util
{
    public class ExcelService : IExcelService
    {
        readonly IRiskService _riskService;

        public ExcelService(IRiskService riskService)
        {
            _riskService = riskService;
        }

        public byte[] GenerateRiskRegisterXml(string projectId)
        {
            var risks = _riskService.GetRisksByProject(projectId);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Project Risks");
                worksheet.ColumnWidth = 30;
                worksheet.Cells().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                var currentRow = 1;
                SetCellStyle(worksheet.Cell(currentRow, 1), "Title", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 2), "Category", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 3), "Impact", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 4), "Likelihood", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 5), "Risk Level", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 6), "Mitigation", false, true, XLColor.LightGray);

                foreach (var risk in risks)
                {
                    currentRow++;
                    SetCellStyle(worksheet.Cell(currentRow, 1), risk.Title, true);
                    SetCellStyle(worksheet.Cell(currentRow, 2), risk.RiskCategotyTitle, true);
                    SetCellStyle(worksheet.Cell(currentRow, 3), risk.Impact.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 4), risk.Likelihood.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 5), GetLevel(risk.Level, worksheet.Cell(currentRow, 5)));
                    SetCellStyle(worksheet.Cell(currentRow, 6), risk.Mitigation, true);
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }

        private string GetLevel(int level, IXLCell cell)
        {
            switch (level)
            {
                case <= 4:
                    cell.Style.Fill.SetBackgroundColor(XLColor.LightGreen);
                    return "Low";
                case > 4 and <= 8:
                    cell.Style.Fill.SetBackgroundColor(XLColor.LightYellow);
                    return "Medium";
                case > 8 and <= 13:
                    cell.Style.Fill.SetBackgroundColor(XLColor.LightApricot);
                    return "High";
                case > 13:
                    cell.Style.Fill.SetBackgroundColor(XLColor.LightCoral);
                    return "Very High";
            }
        }

        private void SetCellStyle(IXLCell cell, string value, bool doWrap = false, bool isBold = false,
            XLColor color = null)
        {
            cell.Value = value;

            if (color != null)
            {
                cell.Style.Fill.SetBackgroundColor(color);
            }

            if (doWrap)
            {
                cell.Style.Alignment.WrapText = true;
            }

            if (isBold)
            {
                cell.RichText.SetBold();
            }
        }
    }
}
