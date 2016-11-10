using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transcript.WebUI.Models
{
    public class AbsenceModel
    {
        public string StudentName { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public int TotalAbsence { get; set; }
    }
}