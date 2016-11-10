using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Transcript.Domain.Interfaces;
using Transcript.Domain.Entities;
using Transcript.WebUI.Controllers;
using System.Web.Mvc;
using Transcript.WebUI.Models;


namespace Transcript.UnitTesting
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Can_Edit_Faculty()
        {
            // Arrange (Организация)
            Mock<IFacultyRepository> mock = new Mock<IFacultyRepository>();

            mock.Setup(_ => _.Faculties).Returns(new List<Faculty>
            {
                new Faculty{Id = 1, Abbreviation = "a1", Name = "n1", Number = 1},
                new Faculty{Id = 2, Abbreviation = "a2", Name = "n2", Number = 2},
                new Faculty{Id = 3, Abbreviation = "a3", Name = "n3", Number = 3},
                new Faculty{Id = 4, Abbreviation = "a4", Name = "n4", Number = 4},
                new Faculty{Id = 5, Abbreviation = "a5", Name = "n5", Number = 5}
            });

            // Act (Действие)
            FacultyController controller = new FacultyController(mock.Object);

            Faculty faculty1 = controller.Edit(1).ViewData.Model as Faculty;
            Faculty faculty2 = controller.Edit(2).ViewData.Model as Faculty;
            Faculty faculty3 = controller.Edit(3).ViewData.Model as Faculty;
            Faculty faculty4 = controller.Edit(4).ViewData.Model as Faculty;
            Faculty faculty5 = controller.Edit(5).ViewData.Model as Faculty;

            // Assert (Утверждение)
            Assert.AreEqual(1, faculty1.Id);
            Assert.AreEqual(2, faculty2.Id);
            Assert.AreEqual(3, faculty3.Id);
            Assert.AreEqual(4, faculty4.Id);
            Assert.AreEqual(5, faculty5.Id);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexists_Faculty()
        {
            // Arrange (Организация)
            Mock<IFacultyRepository> mock = new Mock<IFacultyRepository>();

            mock.Setup(_ => _.Faculties).Returns(new List<Faculty>
            {
                new Faculty{Id = 1, Abbreviation = "a1", Name = "n1", Number = 1},
                new Faculty{Id = 2, Abbreviation = "a2", Name = "n2", Number = 2},
                new Faculty{Id = 3, Abbreviation = "a3", Name = "n3", Number = 3},
                new Faculty{Id = 4, Abbreviation = "a4", Name = "n4", Number = 4},
                new Faculty{Id = 5, Abbreviation = "a5", Name = "n5", Number = 5}
            });

            // Act (Действие)
            FacultyController controller = new FacultyController(mock.Object);

            Faculty result = controller.Edit(7).ViewData.Model as Faculty;

            // Assert (Утверждение)
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Index_Contains_All_Faculties()
        {
            // Arrange (Организация)
            Mock<IFacultyRepository> mock = new Mock<IFacultyRepository>();

            mock.Setup(_ => _.Faculties).Returns(new List<Faculty>
            {
                new Faculty{Id = 1, Abbreviation = "F1", Name = "Faculty1", Number = 1},
                new Faculty{Id = 2, Abbreviation = "F2", Name = "Faculty2", Number = 2},
                new Faculty{Id = 3, Abbreviation = "F3", Name = "Faculty3", Number = 3},
                new Faculty{Id = 4, Abbreviation = "F4", Name = "Faculty4", Number = 4},
                new Faculty{Id = 5, Abbreviation = "F5", Name = "Faculty5", Number = 5}
            });

            // Act (Действие)
            FacultyController controller = new FacultyController(mock.Object);

            List<Faculty> result = ((IEnumerable<Faculty>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Groups()
        {
            // Arrange (Организация)
            Mock<IGroupRepository> mock = new Mock<IGroupRepository>();

            mock.Setup(_ => _.Groups).Returns(new List<GroupStudent>
            {
                new GroupStudent{Id = 1, Name = "Group1", Course = 1, QualificationId = 1, SpecialityId = 1},
                new GroupStudent{Id = 2, Name = "Group2", Course = 2, QualificationId = 2, SpecialityId = 2},
                new GroupStudent{Id = 3, Name = "Group3", Course = 3, QualificationId = 3, SpecialityId = 3},
                new GroupStudent{Id = 4, Name = "Group4", Course = 4, QualificationId = 4, SpecialityId = 4},
                new GroupStudent{Id = 5, Name = "Group5", Course = 5, QualificationId = 5, SpecialityId = 5}
            });

            // Act (Действие)
            GroupController controller = new GroupController(mock.Object);

            List<GroupStudent> result = ((IEnumerable<GroupStudent>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Specialities()
        {
            // Arrange (Организация)
            Mock<ISpecialityRepository> mock = new Mock<ISpecialityRepository>();

            mock.Setup(_ => _.Specialities).Returns(new List<Speciality>
            {
                new Speciality{Id = 1, Name = "Spec1", Abbreviation = "S1", Code = "1", DepartmentId = 1},
                new Speciality{Id = 2, Name = "Spec2", Abbreviation = "S2", Code = "2", DepartmentId = 2},
                new Speciality{Id = 3, Name = "Spec3", Abbreviation = "S3", Code = "3", DepartmentId = 3},
                new Speciality{Id = 4, Name = "Spec4", Abbreviation = "S4", Code = "4", DepartmentId = 4},
                new Speciality{Id = 5, Name = "Spec5", Abbreviation = "S5", Code = "5", DepartmentId = 5}
            });

            // Act (Действие)
            SpecialityController controller = new SpecialityController(mock.Object);

            List<Speciality> result = ((IEnumerable<Speciality>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Students()
        {
            // Arrange (Организация)
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();

            mock.Setup(_ => _.Students).Returns(new List<Student>
            {
                new Student{Id = 1, FirstName = "FN1", GroupId = 1, MiddleName = "MN1", SecondName = "SN1"},
                new Student{Id = 2, FirstName = "FN2", GroupId = 2, MiddleName = "MN2", SecondName = "SN2"},
                new Student{Id = 3, FirstName = "FN3", GroupId = 3, MiddleName = "MN3", SecondName = "SN3"},
                new Student{Id = 4, FirstName = "FN4", GroupId = 4, MiddleName = "MN4", SecondName = "SN4"},
                new Student{Id = 5, FirstName = "FN5", GroupId = 5, MiddleName = "MN5", SecondName = "SN5"}
            });

            // Act (Действие)
            StudentController controller = new StudentController(mock.Object);

            List<Student> result = ((IEnumerable<Student>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Subjects()
        {
            // Arrange (Организация)
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();

            mock.Setup(_ => _.Subjects).Returns(new List<Subject>
            {
                new Subject{Id = 1, Abbreviation = "S1", DepartmentId = 1, Name = "Sub1"},
                new Subject{Id = 2, Abbreviation = "S2", DepartmentId = 2, Name = "Sub2"},
                new Subject{Id = 3, Abbreviation = "S3", DepartmentId = 3, Name = "Sub3"},
                new Subject{Id = 4, Abbreviation = "S4", DepartmentId = 4, Name = "Sub4"},
                new Subject{Id = 5, Abbreviation = "S5", DepartmentId = 5, Name = "Sub5"}
            });

            // Act (Действие)
            SubjectController controller = new SubjectController(mock.Object);

            List<Subject> result = ((IEnumerable<Subject>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Transcripts()
        {
            // Arrange (Организация)
            Mock<ITranscriptRepository> mock = new Mock<ITranscriptRepository>();

            mock.Setup(_ => _.Transcripts).Returns(new List<Transcript.Domain.Entities.Transcript>
            {
                new Transcript.Domain.Entities.Transcript{Id = 1, Mark = 1, Semester = 1, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeControlId = 1, Year = 2016},
                new Transcript.Domain.Entities.Transcript{Id = 2, Mark = 2, Semester = 2, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeControlId = 2, Year = 2016},
                new Transcript.Domain.Entities.Transcript{Id = 3, Mark = 3, Semester = 3, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeControlId = 3, Year = 2016},
                new Transcript.Domain.Entities.Transcript{Id = 4, Mark = 4, Semester = 4, StudentId = 4, SubjectId = 4, TeacherId = 4, TypeControlId = 4, Year = 2016},
                new Transcript.Domain.Entities.Transcript{Id = 5, Mark = 5, Semester = 5, StudentId = 5, SubjectId = 5, TeacherId = 5, TypeControlId = 5, Year = 2016}
            });

            // Act (Действие)
            TranscriptController controller = new TranscriptController(mock.Object);

            List<Transcript.Domain.Entities.Transcript> result = ((IEnumerable<Transcript.Domain.Entities.Transcript>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Teachers()
        {
            // Arrange (Организация)
            Mock<ITeacherRepository> mock = new Mock<ITeacherRepository>();

            mock.Setup(_ => _.Teachers).Returns(new List<UniversityTeacher>
            {
                new UniversityTeacher{Id = 1, DepartmentId = 1, FirstName = "FN1", MiddleName = "MN1", PositionId = 1, SecondName = "SN1"},
                new UniversityTeacher{Id = 2, DepartmentId = 2, FirstName = "FN2", MiddleName = "MN2", PositionId = 2, SecondName = "SN2"},
                new UniversityTeacher{Id = 3, DepartmentId = 3, FirstName = "FN3", MiddleName = "MN3", PositionId = 3, SecondName = "SN3"},
                new UniversityTeacher{Id = 4, DepartmentId = 4, FirstName = "FN4", MiddleName = "MN4", PositionId = 4, SecondName = "SN4"},
                new UniversityTeacher{Id = 5, DepartmentId = 5, FirstName = "FN5", MiddleName = "MN5", PositionId = 5, SecondName = "SN5"}
            });

            // Act (Действие)
            TeacherController controller = new TeacherController(mock.Object);

            List<UniversityTeacher> result = ((IEnumerable<UniversityTeacher>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void Index_Contains_All_Users()
        {
            // Arrange (Организация)
            Mock<IUserRepository> mock = new Mock<IUserRepository>();

            mock.Setup(_ => _.Users).Returns(new List<User>
            {
                new User{Id = 1, Login = "L1", Password = "P1"},
                new User{Id = 2, Login = "L2", Password = "P2"},
                new User{Id = 3, Login = "L3", Password = "P3"},
                new User{Id = 4, Login = "L4", Password = "P4"},
                new User{Id = 5, Login = "L5", Password = "P5"}
            });

            // Act (Действие)
            UserController controller = new UserController(mock.Object);

            List<User> result = ((IEnumerable<User>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        [TestMethod]
        public void User_Success_Authorize()
        {
            // Arrange (Организация)
            string expected = "AdminPanel";

            var mock = new Mock<IUserRepository>();

            mock.Setup(_ => _.Users).Returns(new List<User>
            {
                new User{Id = 1, Login = "L1", Password = "P1"},
                new User{Id = 2, Login = "L2", Password = "P2"},
                new User{Id = 3, Login = "L3", Password = "P3"},
                new User{Id = 4, Login = "L4", Password = "P4"},
                new User{Id = 5, Login = "L5", Password = "P5"}
            });

            LoginModel loginModel = new LoginModel
            {
                login = "L1",
                password = "P1"
            };

            AccountController controller = new AccountController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Login(loginModel) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void User_Failed_Authorize()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IUserRepository>();

            mock.Setup(_ => _.Users).Returns(new List<User>
            {
                new User{Id = 1, Login = "L1", Password = "P1"},
                new User{Id = 2, Login = "L2", Password = "P2"},
                new User{Id = 3, Login = "L3", Password = "P3"},
                new User{Id = 4, Login = "L4", Password = "P4"},
                new User{Id = 5, Login = "L5", Password = "P5"}
            });

            LoginModel loginModel = new LoginModel
            {
                login = "L6",
                password = "P6"
            };

            AccountController controller = new AccountController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Login(loginModel) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }
    }
}
