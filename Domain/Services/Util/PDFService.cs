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

            PdfGrid objectiveGrid = new PdfGrid();

            objectiveGrid.Columns.Add(3);

            objectiveGrid.Headers.Add(1);
            objectiveGrid.Headers[0].Cells[0].Value = "Title";
            objectiveGrid.Headers[0].Cells[1].Value = "Description";
            objectiveGrid.Headers[0].Cells[2].Value = "Priority";


            foreach (var obj in project.Objectives)
            {
                var objectiveRow = objectiveGrid.Rows.Add();
                objectiveRow.Cells[0].Value = obj.Title;
                objectiveRow.Cells[1].Value = obj.Description;
                objectiveRow.Cells[2].Value = obj.Priority.GetDisplayName();
            }

            objectivesRow.Cells[1].Value = objectiveGrid;


            //second row
            var assumptionsRow = pdfGrid.Rows.Add();
            assumptionsRow.Cells[0].Value = "Assumptions";

            PdfGrid assumptionsGrid = new PdfGrid();

            assumptionsGrid.Columns.Add(1);

            assumptionsGrid.Headers.Add(1);
            assumptionsGrid.Headers[0].Cells[0].Value = "Description";

            foreach (var assump in project.Assumptions)
            {
                var assumptionRow = assumptionsGrid.Rows.Add();
                assumptionRow.Cells[0].Value = assump.Description;
            }

            assumptionsRow.Cells[1].Value = assumptionsGrid;

            //third row
            var candidatesRow = pdfGrid.Rows.Add();
            candidatesRow.Cells[0].Value = "Candidates";

            PdfGrid candidatesGrid = new PdfGrid();

            candidatesGrid.Columns.Add(8);

            candidatesGrid.Headers.Add(1);
            candidatesGrid.Headers[0].Cells[0].Value = "Skill";
            candidatesGrid.Headers[0].Cells[0].Value = "Proficiency";
            candidatesGrid.Headers[0].Cells[0].Value = "FTE";
            candidatesGrid.Headers[0].Cells[0].Value = "English Level";
            candidatesGrid.Headers[0].Cells[0].Value = "Internal Rate";
            candidatesGrid.Headers[0].Cells[0].Value = "External Rate";
            candidatesGrid.Headers[0].Cells[0].Value = "Employee";

            foreach (var cand in project.Candidates)
            {
                var candidateRow = candidatesGrid.Rows.Add();
                candidateRow.Cells[0].Value = cand.Skill.Title;
                candidateRow.Cells[1].Value = cand.Proficiency;
                candidateRow.Cells[2].Value = cand.FTE;
                candidateRow.Cells[3].Value = cand.EnglishLevel;
                candidateRow.Cells[4].Value = cand.InternalRate;
                candidateRow.Cells[5].Value = cand.ExternalRate;
                candidateRow.Cells[6].Value = cand?.Employee.Name;
            }

            assumptionsRow.Cells[1].Value = assumptionsGrid;

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
