using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;
using Transcript.WebUI.Controllers;
using Transcript.WebUI.Models;

namespace Transcript.UnitTesting.UnitTests
{
    [TestClass]
    public class AbsenceTests
    {
        /// <summary>
        /// Тестирование метода Index
        /// </summary>
        [TestMethod]
        public void Index_Contains_All_Absences()
        {
            // Arrange (Организация)
            Mock<IAbsenceRepository> mock = new Mock<IAbsenceRepository>();

            mock.Setup(_ => _.Absences).Returns(new List<Absence>
            {
                new Absence{Id = 1, DateAbsence = DateTime.Now, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeClassId = 1},
                new Absence{Id = 2, DateAbsence = DateTime.Now, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeClassId = 2},
                new Absence{Id = 3, DateAbsence = DateTime.Now, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeClassId = 3},
                new Absence{Id = 4, DateAbsence = DateTime.Now, StudentId = 4, SubjectId = 4, TeacherId = 4, TypeClassId = 4},
                new Absence{Id = 5, DateAbsence = DateTime.Now, StudentId = 5, SubjectId = 5, TeacherId = 5, TypeClassId = 5}
            });

            // Act (Действие)
            AbsenceController controller = new AbsenceController(mock.Object);

            List<Absence> result = ((IEnumerable<Absence>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        /// <summary>
        /// Тестирование метода Create, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void CreatePostAction_RedirectToIndexView_Absence()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Create(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Create, а именно проверка выполнения добавления и сохранения
        /// </summary>
        [TestMethod]
        public void CreatePostAction_SaveModel_Absence()
        {
            // Arrange (Организация)
            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            absence.Id = 1;

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Create(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Create(absence));
        }

        /// <summary>
        /// Тестирование метода Edit, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void EditPostAction_RedirectToIndexView_Absence()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            absence.Id = 1;

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Edit(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Edit, а именно проверка выполнения редактирования и сохранения
        /// </summary>
        [TestMethod]
        public void EditPostAction_SaveModel_Absence()
        {
            // Arrange (Организация)
            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            absence.Id = 1;

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Edit(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Edit(absence));
        }

        /// <summary>
        /// Тестирование метода Delete, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void DeletePostAction_RedirectToIndexView_Absence()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            absence.Id = 1;

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.DeleteConfirmed(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Delete, а именно проверка выполнения удаления и сохранения
        /// </summary>
        [TestMethod]
        public void DeletePostAction_SaveModel_Absence()
        {
            // Arrange (Организация)
            var mock = new Mock<IAbsenceRepository>();

            Absence absence = new Absence();

            absence.Id = 1;

            AbsenceController controller = new AbsenceController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.DeleteConfirmed(absence) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Delete(absence.Id));
        }

        /// <summary>
        /// Проверка правильности определения записи для редактирования
        /// </summary>
        [TestMethod]
        public void Can_Edit_Absence()
        {
            // Arrange (Организация)
            Mock<IAbsenceRepository> mock = new Mock<IAbsenceRepository>();

            mock.Setup(_ => _.Absences).Returns(new List<Absence>
            {
                new Absence{Id = 1, DateAbsence = DateTime.Now, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeClassId = 1},
                new Absence{Id = 2, DateAbsence = DateTime.Now, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeClassId = 2},
                new Absence{Id = 3, DateAbsence = DateTime.Now, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeClassId = 3},
                new Absence{Id = 4, DateAbsence = DateTime.Now, StudentId = 4, SubjectId = 4, TeacherId = 4, TypeClassId = 4},
                new Absence{Id = 5, DateAbsence = DateTime.Now, StudentId = 5, SubjectId = 5, TeacherId = 5, TypeClassId = 5}
            });

            // Act (Действие)
            AbsenceController controller = new AbsenceController(mock.Object);

            Absence absence1 = controller.Edit(1).ViewData.Model as Absence;
            Absence absence2 = controller.Edit(2).ViewData.Model as Absence;
            Absence absence3 = controller.Edit(3).ViewData.Model as Absence;
            Absence absence4 = controller.Edit(4).ViewData.Model as Absence;
            Absence absence5 = controller.Edit(5).ViewData.Model as Absence;

            // Assert (Утверждение)
            Assert.AreEqual(1, absence1.Id);
            Assert.AreEqual(2, absence2.Id);
            Assert.AreEqual(3, absence3.Id);
            Assert.AreEqual(4, absence4.Id);
            Assert.AreEqual(5, absence5.Id);
        }

        /// <summary>
        /// Проверка правильности определения записи для удаления
        /// </summary>
        [TestMethod]
        public void Can_Delete_Absence()
        {
            // Arrange (Организация)
            Mock<IAbsenceRepository> mock = new Mock<IAbsenceRepository>();

            mock.Setup(_ => _.Absences).Returns(new List<Absence>
            {
                new Absence{Id = 1, DateAbsence = DateTime.Now, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeClassId = 1},
                new Absence{Id = 2, DateAbsence = DateTime.Now, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeClassId = 2},
                new Absence{Id = 3, DateAbsence = DateTime.Now, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeClassId = 3},
                new Absence{Id = 4, DateAbsence = DateTime.Now, StudentId = 4, SubjectId = 4, TeacherId = 4, TypeClassId = 4},
                new Absence{Id = 5, DateAbsence = DateTime.Now, StudentId = 5, SubjectId = 5, TeacherId = 5, TypeClassId = 5}
            });

            Absence absence = new Absence();

            absence.Id = 1;

            // Act (Действие)
            AbsenceController controller = new AbsenceController(mock.Object);

            Absence result = controller.Delete(absence).ViewData.Model as Absence;

            // Assert (Утверждение)
            Assert.AreEqual(absence.Id, result.Id);
        }

        /// <summary>
        /// Проверка правильности определения записи для редактирования, а именно если передана неправильная запись
        /// </summary>
        [TestMethod]
        public void Cannot_Edit_Nonexists_Absence()
        {
            // Arrange (Организация)
            Mock<IAbsenceRepository> mock = new Mock<IAbsenceRepository>();

            mock.Setup(_ => _.Absences).Returns(new List<Absence>
            {
                new Absence{Id = 1, DateAbsence = DateTime.Now, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeClassId = 1},
                new Absence{Id = 2, DateAbsence = DateTime.Now, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeClassId = 2},
                new Absence{Id = 3, DateAbsence = DateTime.Now, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeClassId = 3},
                new Absence{Id = 4, DateAbsence = DateTime.Now, StudentId = 4, SubjectId = 4, TeacherId = 4, TypeClassId = 4},
                new Absence{Id = 5, DateAbsence = DateTime.Now, StudentId = 5, SubjectId = 5, TeacherId = 5, TypeClassId = 5}
            });

            // Act (Действие)
            AbsenceController controller = new AbsenceController(mock.Object);

            Absence result = controller.Edit(8).ViewData.Model as Absence;

            // Assert (Утверждение)
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetList_Absenced()
        {
            // Arrange (Организация)
            Mock<IAbsenceRepository> mock = new Mock<IAbsenceRepository>();

            mock.Setup(_ => _.Absences).Returns(new List<Absence>
            {
                new Absence{Id = 1, DateAbsence = DateTime.Now, StudentId = 1, SubjectId = 1, TeacherId = 1, TypeClassId = 1, 
                            Student = new Student{FirstName = "S1", Id = 1, MiddleName = "S1", SecondName = "S1", Group = new GroupStudent{Name = "G1"}}, 
                            Subject = new Subject{Name = "Sub1"}, 
                            Teacher = new UniversityTeacher{FirstName = "S1", Id = 1, MiddleName = "S1", SecondName = "S1"}
                },
                new Absence{Id = 2, DateAbsence = DateTime.Now, StudentId = 2, SubjectId = 2, TeacherId = 2, TypeClassId = 2, 
                            Student = new Student{FirstName = "S2", Id = 2, MiddleName = "S2", SecondName = "S2", Group = new GroupStudent{Name = "G2"}}, 
                            Subject = new Subject{Name = "Sub2"}, 
                            Teacher = new UniversityTeacher{FirstName = "S2", Id = 2, MiddleName = "S2", SecondName = "S2"}
                },
                new Absence{Id = 3, DateAbsence = DateTime.Now, StudentId = 3, SubjectId = 3, TeacherId = 3, TypeClassId = 3, 
                            Student = new Student{FirstName = "S3", Id = 3, MiddleName = "S3", SecondName = "S3", Group = new GroupStudent{Name = "G3"}}, 
                            Subject = new Subject{Name = "Sub3"}, 
                            Teacher = new UniversityTeacher{FirstName = "S3", Id = 3, MiddleName = "S3", SecondName = "S3"}
                }
            });

            // Act (Действие)
            StatisticsAbsenceController controller = new StatisticsAbsenceController(mock.Object);

            List<AbsenceModel> result = controller.GetAbsence();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 3);
        }
    }
}
