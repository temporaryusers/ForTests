using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transcript.Domain.Context;
using Transcript.WebUI.Models;

namespace Transcript.WebUI.Controllers
{
    public class StatisticsTranscriptController : Controller
    {
        private EFDbContext db = new EFDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public List<TranscriptModel> GetTranscript()
        {
            List<TranscriptModel> data = new List<TranscriptModel>();

            foreach (var item in db.Transcripts.ToList())
            {
                data.Add(new TranscriptModel
                {
                    Mark = item.Mark.Value,
                    Semester = item.Semester.Value,
                    StudentName = string.Format("{0} {1} {2}", item.Student.SecondName, item.Student.FirstName, item.Student.MiddleName),
                    SubjectName = item.Subject.Name,
                    GroupName = item.Student.Group.Name,
                    TeacherName = string.Format("{0} {1} {2}", item.Teacher.SecondName, item.Teacher.FirstName, item.Teacher.MiddleName),
                    TypeControlName = item.TypeControl.Name,
                    Year = item.Year.Value
                });
            }

            return data;
        }
        
        public string GetData()
        {


            return JsonConvert.SerializeObject(GetTranscript());
        }

        public ActionResult ExportToExcel()
        {
            var data = GetTranscript();

            var grid = new GridView();

            grid.DataSource = data;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Transcripts.xls");

            Response.ContentType = "application/excel";

            StringWriter sw = new StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

            return View("Index");
        }
    }
}