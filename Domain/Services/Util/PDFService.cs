using Domain.Models.Dtos.Responses;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Domain.Interfaces.Services.Util;
using System.Data;
using Syncfusion.Pdf.Tables;
using Microsoft.OpenApi.Extensions;

namespace Domain.Services.Util
{
    public class PDFService : IPDFService
    {
        public Stream GenerateProjectCharter(ProjectResponse project)
        {

            PdfDocument document = new PdfDocument();

            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            document.PageSettings.Margins.All = 50;
            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            #region Title
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 18, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            graphics.DrawString("Project Charter", font, PdfBrushes.Black, new RectangleF(200, 0, 300, 250), format);
            #endregion

            #region Summary
            PdfLightTable pdfLightTable = new PdfLightTable();
            //Initialize DataTable to assign as DataSource to the light table.
            DataTable table = new DataTable();
            //Include columns to the DataTable.
            table.Columns.Add();
            table.Columns.Add();
            table.Columns.Add();
            table.Columns.Add();

            //Include rows to the DataTable.
            table.Rows.Add(new string[] { "Project Title", project.Title, "Date", DateTime.UtcNow.Date.ToString("dd/mm/yyyy") });
            table.Rows.Add(new string[] { "Projet Manager", project.Manager.Name, "Project Sponsor", GetSponsorName(project) });
            // Assign data source.
            pdfLightTable.DataSource = table;
            // Draw PdfLightTable.
            pdfLightTable.Draw(page, new PointF(0, 50));
            #endregion

            PdfGrid pdfGrid = new PdfGrid();

            pdfGrid.Columns.Add(2);
            pdfGrid.Columns[0].Width = 75f;

            //first row
            var objectivesRow = pdfGrid.Rows.Add();
            objectivesRow.Cells[0].Value = "Objectives";

            var objectives = "";
            foreach (var obj in project.Objectives)
            {

                objectives += obj.Description + " [ " + obj.Title + " ] " + " [ " + obj.Priority + " ] " + "\n";
            }
            objectivesRow.Cells[1].Value = objectives;


            //second row
            var assumptionsRow = pdfGrid.Rows.Add();
            assumptionsRow.Cells[0].Value = "Assumptions";

            var assumptions = "";
            foreach (var assump in project.Assumptions)
            {
                assumptions += assump.Description + "\n";
            }
            assumptionsRow.Cells[1].Value = assumptions;

            //third row
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

            //forth row
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
            //fifth row
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

            //sixth row
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

            //seventh row
            var risksRow = pdfGrid.Rows.Add();
            risksRow.Cells[0].Value = "Risks";

            PdfGrid risksGrid = new PdfGrid();

            risksGrid.Columns.Add(3);

            risksGrid.Headers.Add(1);
            risksGrid.Headers[0].Cells[0].Value = "Desctiption";
            risksGrid.Headers[0].Cells[1].Value = "Category";
            risksGrid.Headers[0].Cells[2].Value = "Mitigation";

            foreach (var risk in project.Risks)
            {
                var riskRow = risksGrid.Rows.Add();
                riskRow.Cells[0].Value = risk.RiskCategory.Title;
                _ = risk.Description == null ? riskRow.Cells[1].Value = "" : riskRow.Cells[1].Value = risk.Description;
                _ = risk.Mitigation == null ? riskRow.Cells[2].Value = "" : riskRow.Cells[2].Value = risk.Mitigation;
            }

            risksRow.Cells[1].Value = risksGrid;
            //risksRow.Cells[1].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);

            pdfGrid.Draw(page, new PointF(0f, 100f));

            //Save the PDF document to stream
            MemoryStream stream = new();
            document.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            document.Close(true);

            return stream;
        }

        private string GetSponsorName(ProjectResponse project)
        {
            var sponsor = project.Stakeholders
                .Where(st => st.Role == Models.Constants.StakeholderRole.Sponsor)
                .FirstOrDefault();

            if (sponsor != null)
            {
                return sponsor.Name;
            }
            else
            {
                return "";
            }
        }
    }
}
