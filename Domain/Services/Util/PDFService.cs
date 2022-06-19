using Domain.Models.Dtos.Responses;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Domain.Interfaces.Services.Util;
using System.Data;
using Microsoft.OpenApi.Extensions;

namespace Domain.Services.Util
{
    public class PDFService : IPDFService
    {
        public Stream GenerateProjectCharter(ProjectResponse project)
        {
            PdfDocument document = new();

            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 50;

            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            #region Title
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 18, PdfFontStyle.Bold);
            PdfStringFormat format = new();
            format.Alignment = PdfTextAlignment.Center;
            graphics.DrawString("Project Charter", font, PdfBrushes.Black, new RectangleF(100, 0, 300, 250), format);
            #endregion

            PdfGrid pdfGrid = new PdfGrid();

            pdfGrid.Columns.Add(2);
            pdfGrid.Columns[0].Width = 75f;

            #region General Rows
            var titleRow = pdfGrid.Rows.Add();
            titleRow.Cells[0].Value = "Title";
            titleRow.Cells[1].Value = project.Title;

            var descriptionRow = pdfGrid.Rows.Add();
            descriptionRow.Cells[0].Value = "Description";
            descriptionRow.Cells[1].Value = project.Description;

            var budgetRow = pdfGrid.Rows.Add();
            budgetRow.Cells[0].Value = "Resources";
            budgetRow.Cells[1].Value = "Approximate monthly budget: " + project.MonthlyIncome.ToString();
            #endregion

            #region Objectives
            var objectivesRow = pdfGrid.Rows.Add();
            objectivesRow.Cells[0].Value = "Objectives";

            var objectives = "";
            foreach (var obj in project.Objectives)
            {
                objectives += obj.Description + " [ " + obj.Title + " ] " + " [ " + obj.Priority + " ] " + "\n";
            }
            objectivesRow.Cells[1].Value = objectives;
            #endregion

            #region Assumptions
            var assumptionsRow = pdfGrid.Rows.Add();
            assumptionsRow.Cells[0].Value = "Assumptions";

            var assumptions = "";
            foreach (var assump in project.Assumptions)
            {
                assumptions += assump.Description + "\n";
            }
            assumptionsRow.Cells[1].Value = assumptions;
            #endregion

            #region Candidates
            var candidatesRow = pdfGrid.Rows.Add();
            candidatesRow.Cells[0].Value = "Candidates";

            PdfGrid candidatesGrid = new PdfGrid();

            candidatesGrid.Columns.Add(5);

            candidatesGrid.Headers.Add(1);
            candidatesGrid.Headers[0].Cells[0].Value = "Skill";
            candidatesGrid.Headers[0].Cells[1].Value = "FTE";
            candidatesGrid.Headers[0].Cells[2].Value = "English Level";
            candidatesGrid.Headers[0].Cells[3].Value = "External Rate";
            candidatesGrid.Headers[0].Cells[4].Value = "Employee";

            foreach (var cand in project.Candidates)
            {
                var candidateRow = candidatesGrid.Rows.Add();
                candidateRow.Cells[0].Value = cand.Skill.Title;
                candidateRow.Cells[1].Value = cand.FTE.ToString();
                candidateRow.Cells[2].Value = cand.EnglishLevel.GetDisplayName();
                candidateRow.Cells[3].Value = cand.ExternalRate.ToString();
                _ = cand.Employee == null ? candidateRow.Cells[4].Value = "" : candidateRow.Cells[4].Value = cand.Employee.Name;
            }

            candidatesRow.Cells[1].Value = candidatesGrid;
            candidatesRow.Cells[1].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
            #endregion

            #region Stakeholders
            var stakeholdersRow = pdfGrid.Rows.Add();
            stakeholdersRow.Cells[0].Value = "Stakeholders";

            PdfGrid stakeholdersGrid = new PdfGrid();

            stakeholdersGrid.Columns.Add(5);

            stakeholdersGrid.Headers.Add(1);
            stakeholdersGrid.Headers[0].Cells[0].Value = "Name";
            stakeholdersGrid.Headers[0].Cells[1].Value = "Email";
            stakeholdersGrid.Headers[0].Cells[2].Value = "Role";
            stakeholdersGrid.Headers[0].Cells[3].Value = "Category";
            stakeholdersGrid.Headers[0].Cells[4].Value = "Address";

            foreach (var stak in project.Stakeholders)
            {
                var stakeholderRow = stakeholdersGrid.Rows.Add();
                stakeholderRow.Cells[0].Value = stak.Name;
                stakeholderRow.Cells[1].Value = stak.Email;
                stakeholderRow.Cells[2].Value = stak.Role.GetDisplayName();
                stakeholderRow.Cells[3].Value = stak.Category.GetDisplayName();
                stakeholderRow.Cells[4].Value = stak.Address;
            }
            stakeholdersRow.Cells[1].Value = stakeholdersGrid;
            stakeholdersRow.Cells[1].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
            #endregion

            #region Deliverables
            var deliverablesRow = pdfGrid.Rows.Add();
            deliverablesRow.Cells[0].Value = "Deliverables";

            var deliverables = "";
            var i = 0;

            foreach (var del in project.Deliverables)
            {
                i++;
                deliverables += i + " ) " + del.Title + ": " + del.Description + " [ " + del.TimeOfComplition.Date.ToString() + " ] " + "\n";
            }

            deliverablesRow.Cells[1].Value = deliverables;
            #endregion

            #region Milestones
            var milestonesRow = pdfGrid.Rows.Add();
            milestonesRow.Cells[0].Value = "Milestones";

            PdfGrid milestonesGrid = new PdfGrid();

            milestonesGrid.Columns.Add(3);

            var milestones = "";
            foreach (var mil in project.Milestones)
            {
                string milDeliverables = "";

                foreach (var del in mil.Deliverables)
                {
                    milDeliverables += "(" + del.Title + "])";
                }
                milestones += mil.Activity + " [ " + mil.DueDate.ToString() + " ] " + milDeliverables + "\n";
            }
            milestonesRow.Cells[1].Value = milestones;
            #endregion

            #region Risks
            var risksRow = pdfGrid.Rows.Add();
            risksRow.Cells[0].Value = "Risks";

            PdfGrid risksGrid = new();

            risksGrid.Columns.Add(3);

            risksGrid.Headers.Add(1);
            risksGrid.Headers[0].Cells[0].Value = "Category";
            risksGrid.Headers[0].Cells[1].Value = "Title";
            risksGrid.Headers[0].Cells[2].Value = "Mitigation";

            foreach (var risk in project.Risks)
            {
                var riskRow = risksGrid.Rows.Add();
                riskRow.Cells[0].Value = risk.RiskCategory.Title;
                _ = risk.Title == null ? riskRow.Cells[1].Value = "" : riskRow.Cells[1].Value = risk.Title;
                _ = risk.Mitigation == null ? riskRow.Cells[2].Value = "" : riskRow.Cells[2].Value = risk.Mitigation;
            }

            risksRow.Cells[1].Value = risksGrid;
            risksRow.Cells[1].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);

            #endregion

            #region Approval
            var approvalRow = pdfGrid.Rows.Add();
            approvalRow.Cells[0].Value = "Approval";

            PdfGrid approvalGrid = new PdfGrid();

            approvalGrid.Columns.Add(2);

            approvalGrid.Headers.Add(1);
            approvalGrid.Headers[0].Cells[0].Value = "Title and name";
            approvalGrid.Headers[0].Cells[1].Value = "Date";

            var row = approvalGrid.Rows.Add();

            row.Cells[0].Value = "Sponsor: " + GetSponsorName(project) + "\n" +
                "signature: _______________" + "\n" +
                "Manager: " + project.Manager.Name +
                "\n" + "signature: _______________";
            row.Cells[1].Value = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy");

            approvalRow.Cells[1].Value = approvalGrid;
            approvalRow.Cells[1].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
            #endregion

            pdfGrid.Draw(page, new PointF(0f, 40f));

            MemoryStream stream = new();
            document.Save(stream);
            stream.Position = 0;
            document.Close(true);

            return stream;
        }

        private string GetSponsorName(ProjectResponse project)
        {
            var sponsor = project.Stakeholders
                .Where(st => st.Role == Models.Constants.StakeholderRole.Sponsor)
                .FirstOrDefault();

            return sponsor == null ? null : sponsor.Name;
        }
    }
}
