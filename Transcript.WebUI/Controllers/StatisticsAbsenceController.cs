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
using Transcript.Domain.Interfaces;
using Transcript.WebUI.Models;

namespace Transcript.WebUI.Controllers
{
    public class StatisticsAbsenceController : Controller
    {
        private IAbsenceRepository repository;

        public StatisticsAbsenceController(IAbsenceRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(GetAbsence());
        }

        public List<AbsenceModel> GetAbsence()
        {
            var students = repository.Absences.ToList().GroupBy(_ => _.StudentId).Select(_ => _.First()).ToList();

            List<AbsenceModel> data = new List<AbsenceModel>();

            foreach (var student in students)
            {
                var subjects = repository.Absences.Where(_ => _.StudentId == student.StudentId).ToList().GroupBy(_ => _.SubjectId).Select(_ => _.First()).ToList();
                foreach (var subject in subjects)
                {
                    var teachers = repository.Absences.Where(_ => _.SubjectId == subject.SubjectId && _.StudentId == student.StudentId).ToList().GroupBy(_ => _.TeacherId).Select(_ => _.First()).ToList();
                    foreach (var item in teachers)
                    {
                        data.Add(new AbsenceModel
                        {
                            GroupName = item.Student.Group.Name,
                            StudentName = string.Format("{0} {1} {2}", item.Student.SecondName, item.Student.FirstName, item.Student.MiddleName),
                            SubjectName = item.Subject.Name,
                            TeacherName = string.Format("{0} {1} {2}", item.Teacher.SecondName, item.Teacher.FirstName, item.Teacher.MiddleName),
                            TotalAbsence = repository.Absences.Count(_ => _.StudentId == item.StudentId && _.SubjectId == item.SubjectId && _.TeacherId == item.TeacherId) * 2
                        });
                    }
                }
            }

            return data;
        }

        public ActionResult ExportToExcel()
        {
            var data = GetAbsence();

            var grid = new GridView();

            grid.DataSource = data;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Absences.xls");

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