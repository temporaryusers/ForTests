using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transcript.WebUI.Models
{
    public class TranscriptModel
    {
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string TypeControlName { get; set; }
        public string GroupName { get; set; }
        public int Mark { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}