using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;
using Transcript.Domain.Repositories;

namespace Transcript.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IAbsenceRepository>().To<AbsenceRepository>();

            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();

            kernel.Bind<IFacultyRepository>().To<FacultyRepository>();

            kernel.Bind<IGroupRepository>().To<GroupRepository>();

            kernel.Bind<ISpecialityRepository>().To<SpecialityRepository>();

            kernel.Bind<IStudentRepository>().To<StudentRepository>();

            kernel.Bind<ISubjectRepository>().To<SubjectRepository>();

            kernel.Bind<ITranscriptRepository>().To<TranscriptRepository>();

            kernel.Bind<ITeacherRepository>().To<TeacherRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}