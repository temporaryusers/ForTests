using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Department")]
    public class Department
    {
        /// <summary>
        /// Свойство таблицы Кафедра - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Кафедра - название
        /// </summary>
        [Display(Name = "Кафедра")]
        [Required(ErrorMessage = "Введите пожалуйста, название кафедры")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Кафедра - краткое название
        /// </summary>
        [Display(Name = "Абревиатура")]
        [Required(ErrorMessage = "Введите пожалуйста, короткое название кафедры")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Свойство таблицы Кафедра - номер
        /// </summary>
        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Введите пожалуйста, номер кафедры")]
        public int? Number { get; set; }

        /// <summary>
        /// Свойство таблицы Кафедра - внешний ключ таблицы Факультеты
        /// </summary>
        public int? FacultyId { get; set; }

        /// <summary>
        /// Свойство таблицы Кафедра - факультет
        /// </summary>
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// Коллекция специальностей
        /// </summary>
        public virtual ICollection<Speciality> Specialities { get; set; }

        /// <summary>
        /// Коллекция преподавателей кафедры
        /// </summary>
        public virtual ICollection<UniversityTeacher> Teachers { get; set; }

        /// <summary>
        /// Коллекция дисциплин которые читает кафедра
        /// </summary>
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
