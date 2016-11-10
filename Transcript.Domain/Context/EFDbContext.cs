using System.Data.Entity;
using Transcript.Domain.Entities;

namespace Transcript.Domain.Context
{
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// Коллекция кафедр
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Коллекция пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Коллекция факультетов
        /// </summary>
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Коллекция груп
        /// </summary>
        public DbSet<GroupStudent> Groups { get; set; }

        /// <summary>
        /// Коллекция должностей
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Коллекция квалификационных уровней
        /// </summary>
        public DbSet<Qualification> Qualifications { get; set; }

        /// <summary>
        /// Коллекция специальностей
        /// </summary>
        public DbSet<Speciality> Specialities { get; set; }

        /// <summary>
        /// Коллекция дисциплин
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Коллекция типов занятий
        /// </summary>
        public DbSet<TypeClass> TypesClasses { get; set; }

        /// <summary>
        /// Коллекция типов контролей
        /// </summary>
        public DbSet<TypeControl> TypesControl { get; set; }

        /// <summary>
        /// Коллекция преподавателей
        /// </summary>
        public DbSet<UniversityTeacher> Teachers { get; set; }

        /// <summary>
        /// Коллекция Отсутствий
        /// </summary>
        public DbSet<Absence> Absences { get; set; }

        /// <summary>
        /// Коллекция Студентов
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Коллекция Успеваемостей
        /// </summary>
        public DbSet<Entities.Transcript> Transcripts { get; set; }
    }
}
