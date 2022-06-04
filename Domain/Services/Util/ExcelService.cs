using ClosedXML.Excel;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.OpenApi.Extensions;

namespace Domain.Services.Util
{
    public class ExcelService : IExcelService
    {
        readonly IRiskService _riskService;
        readonly IStakeholdersService _stakeholderService;

        public ExcelService(IRiskService riskService, IStakeholdersService stakeholderService)
        {
            _riskService = riskService;
            _stakeholderService = stakeholderService;
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
                SetCellStyle(worksheet.Cell(currentRow, 3), "Description", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 4), "Consequence", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 5), "Impact", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 6), "Likelihood", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 7), "Risk Level", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 8), "Mitigation", false, true, XLColor.LightGray);

                foreach (var risk in risks)
                {
                    currentRow++;
                    SetCellStyle(worksheet.Cell(currentRow, 1), risk.Title, true);
                    SetCellStyle(worksheet.Cell(currentRow, 2), risk.RiskCategory.Title, true);
                    SetCellStyle(worksheet.Cell(currentRow, 3), risk.Description, true);
                    SetCellStyle(worksheet.Cell(currentRow, 4), risk.Consequence, true);
                    SetCellStyle(worksheet.Cell(currentRow, 5), risk.Impact.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 6), risk.Likelihood.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 7), GetLevel(risk.Level, worksheet.Cell(currentRow, 5)));
                    SetCellStyle(worksheet.Cell(currentRow, 8), risk.Mitigation, true);
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }

        public byte[] GenerateStakeholderRegisterXml(string projectId, string projectName)
        {
            var stakeholders = _stakeholderService.GetStakeholders(projectId);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Project Stakeholders");
                worksheet.ColumnWidth = 15;
                worksheet.Cells().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                var firstRow = 1;
                worksheet.Range("A:K").Row(1).Merge();
                SetCellStyle(worksheet.Cell(firstRow, 1), "Stakeholder Register ", false, true);
                worksheet.Cell(firstRow, 1).Style.Font.FontSize = 18;
                worksheet.Cell(firstRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var secondRow = 2;
                worksheet.Range("A:F").Row(secondRow).Merge();
                SetCellStyle(worksheet.Cell(secondRow, 1), "Project Name", false, true);
                worksheet.Range("G:K").Row(secondRow).Merge();
                SetCellStyle(worksheet.Cell(secondRow, 7), projectName, false, true);
             

                var currentRow = 3;
                SetCellStyle(worksheet.Cell(currentRow, 1), "Name", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 2), "Email", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 3), "Role", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 4), "Category", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 5), "Class", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 6), "Interest", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 7), "Influence", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 8), "Payment", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 9), "Communication Channel", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 10), "Address", false, true, XLColor.LightGray);
                SetCellStyle(worksheet.Cell(currentRow, 11), "Notes", false, true, XLColor.LightGray);

                foreach (var stakeholder in stakeholders)
                {
                    currentRow++;
                    SetCellStyle(worksheet.Cell(currentRow, 1), stakeholder.Name, true);
                    SetCellStyle(worksheet.Cell(currentRow, 2), stakeholder.Email, true);
                    SetCellStyle(worksheet.Cell(currentRow, 3), stakeholder.Role.GetDisplayName(), true);
                    SetCellStyle(worksheet.Cell(currentRow, 4), stakeholder.Category.GetDisplayName(), true);
                    SetCellStyle(worksheet.Cell(currentRow, 5), stakeholder.Class.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 6), stakeholder.Interest.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 7), stakeholder.Influence.GetDisplayName());
                    SetCellStyle(worksheet.Cell(currentRow, 8), stakeholder.Payment.GetDisplayName(), true);
                    if (stakeholder.CommunicationChannel != null)
                    {
                        SetCellStyle(worksheet.Cell(currentRow, 9), stakeholder.CommunicationChannel.GetDisplayName(), true);
                    }
                    else
                    {
                        SetCellStyle(worksheet.Cell(currentRow, 9), "", true);
                    }
                    SetCellStyle(worksheet.Cell(currentRow, 10), stakeholder.Address, true);
                    SetCellStyle(worksheet.Cell(currentRow, 11), stakeholder.Notes, true);
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
