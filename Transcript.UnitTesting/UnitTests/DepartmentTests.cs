using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;
using Transcript.WebUI.Controllers;

namespace Transcript.UnitTesting.UnitTests
{
    [TestClass]
    public class DepartmentTests
    {
        /// <summary>
        /// Тестирование метода Index
        /// </summary>
        [TestMethod]
        public void Index_Contains_All_Departments()
        {
            // Arrange (Организация)
            Mock<IDepartmentRepository> mock = new Mock<IDepartmentRepository>();

            mock.Setup(_ => _.Departments).Returns(new List<Department>
            {
                new Department{Id = 1, FacultyId = 1, Abbreviation = "D1", Name = "Dep1", Number = 1},
                new Department{Id = 2, FacultyId = 2, Abbreviation = "D2", Name = "Dep2", Number = 2},
                new Department{Id = 3, FacultyId = 3, Abbreviation = "D3", Name = "Dep3", Number = 3},
                new Department{Id = 4, FacultyId = 4, Abbreviation = "D4", Name = "Dep4", Number = 4},
                new Department{Id = 5, FacultyId = 5, Abbreviation = "D5", Name = "Dep5", Number = 5}
            });

            // Act (Действие)
            DepartmentController controller = new DepartmentController(mock.Object);

            List<Department> result = ((IEnumerable<Department>)controller.Index().ViewData.Model).ToList();

            // Assert (Утверждение)
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Id, 3);
        }

        /// <summary>
        /// Тестирование метода Create, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void CreatePostAction_RedirectToIndexView_Department()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Create(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Create, а именно проверка выполнения добавления и сохранения
        /// </summary>
        [TestMethod]
        public void CreatePostAction_SaveModel_Department()
        {
            // Arrange (Организация)
            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            department.Id = 1;

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Create(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Create(department));
        }

        /// <summary>
        /// Тестирование метода Edit, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void EditPostAction_RedirectToIndexView_Department()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            department.Id = 1;

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Edit(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Edit, а именно проверка выполнения редактирования и сохранения
        /// </summary>
        [TestMethod]
        public void EditPostAction_SaveModel_Department()
        {
            // Arrange (Организация)
            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            department.Id = 1;

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.Edit(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Edit(department));
        }

        /// <summary>
        /// Тестирование метода Delete, а именно перенаправление на метод Index
        /// </summary>
        [TestMethod]
        public void DeletePostAction_RedirectToIndexView_Department()
        {
            // Arrange (Организация)
            string expected = "Index";

            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            department.Id = 1;

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.DeleteConfirmed(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        /// <summary>
        /// Тестирование метода Delete, а именно проверка выполнения удаления и сохранения
        /// </summary>
        [TestMethod]
        public void DeletePostAction_SaveModel_Department()
        {
            // Arrange (Организация)
            var mock = new Mock<IDepartmentRepository>();

            Department department = new Department();

            department.Id = 1;

            DepartmentController controller = new DepartmentController(mock.Object);

            // Act (Действие)
            RedirectToRouteResult result = controller.DeleteConfirmed(department) as RedirectToRouteResult;

            // Assert (Утверждение)
            mock.Verify(a => a.Delete(department.Id));
        }

        /// <summary>
        /// Проверка правильности определения записи для редактирования
        /// </summary>
        [TestMethod]
        public void Can_Edit_Department()
        {
            // Arrange (Организация)
            Mock<IDepartmentRepository> mock = new Mock<IDepartmentRepository>();

            mock.Setup(_ => _.Departments).Returns(new List<Department>
            {
                new Department{Id = 1, Abbreviation = "D1", FacultyId = 1, Name = "D1", Number = 1},
                new Department{Id = 2, Abbreviation = "D2", FacultyId = 2, Name = "D2", Number = 2},
                new Department{Id = 3, Abbreviation = "D3", FacultyId = 3, Name = "D3", Number = 3},
                new Department{Id = 4, Abbreviation = "D4", FacultyId = 4, Name = "D4", Number = 4},
                new Department{Id = 5, Abbreviation = "D5", FacultyId = 5, Name = "D5", Number = 5}
            });

            // Act (Действие)
            DepartmentController controller = new DepartmentController(mock.Object);

            Department department1 = controller.Edit(1).ViewData.Model as Department;
            Department department2 = controller.Edit(2).ViewData.Model as Department;
            Department department3 = controller.Edit(3).ViewData.Model as Department;
            Department department4 = controller.Edit(4).ViewData.Model as Department;
            Department department5 = controller.Edit(5).ViewData.Model as Department;

            // Assert (Утверждение)
            Assert.AreEqual(1, department1.Id);
            Assert.AreEqual(2, department2.Id);
            Assert.AreEqual(3, department3.Id);
            Assert.AreEqual(4, department4.Id);
            Assert.AreEqual(5, department5.Id);
        }

        /// <summary>
        /// Проверка правильности определения записи для удаления
        /// </summary>
        [TestMethod]
        public void Can_Delete_Department()
        {
            // Arrange (Организация)
            Mock<IDepartmentRepository> mock = new Mock<IDepartmentRepository>();

            mock.Setup(_ => _.Departments).Returns(new List<Department>
            {
                new Department{Id = 1, Abbreviation = "D1", FacultyId = 1, Name = "D1", Number = 1},
                new Department{Id = 2, Abbreviation = "D2", FacultyId = 2, Name = "D2", Number = 2},
                new Department{Id = 3, Abbreviation = "D3", FacultyId = 3, Name = "D3", Number = 3},
                new Department{Id = 4, Abbreviation = "D4", FacultyId = 4, Name = "D4", Number = 4},
                new Department{Id = 5, Abbreviation = "D5", FacultyId = 5, Name = "D5", Number = 5}
            });

            Department department = new Department();

            department.Id = 1;

            // Act (Действие)
            DepartmentController controller = new DepartmentController(mock.Object);

            Department result = controller.Delete(department).ViewData.Model as Department;

            // Assert (Утверждение)
            Assert.AreEqual(department.Id, result.Id);
        }

        /// <summary>
        /// Проверка правильности определения записи для редактирования, а именно если передана неправильная запись
        /// </summary>
        [TestMethod]
        public void Cannot_Edit_Nonexists_Department()
        {
            // Arrange (Организация)
            Mock<IDepartmentRepository> mock = new Mock<IDepartmentRepository>();

            mock.Setup(_ => _.Departments).Returns(new List<Department>
            {
                new Department{Id = 1, Abbreviation = "D1", FacultyId = 1, Name = "D1", Number = 1},
                new Department{Id = 2, Abbreviation = "D2", FacultyId = 2, Name = "D2", Number = 2},
                new Department{Id = 3, Abbreviation = "D3", FacultyId = 3, Name = "D3", Number = 3},
                new Department{Id = 4, Abbreviation = "D4", FacultyId = 4, Name = "D4", Number = 4},
                new Department{Id = 5, Abbreviation = "D5", FacultyId = 5, Name = "D5", Number = 5}
            });

            // Act (Действие)
            DepartmentController controller = new DepartmentController(mock.Object);

            Department result = controller.Edit(8).ViewData.Model as Department;

            // Assert (Утверждение)
            Assert.IsNull(result);
        }
    }
}
