using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("UniversityTeacher")]
    public class UniversityTeacher
    {
        /// <summary>
        /// Свойство таблицы Преподаватели - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите пожалуйста, фамилию преподавателя")]
        public string SecondName { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите пожалуйста, имя преподавателя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - отчество
        /// </summary>
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите пожалуйста, отчество преподавателя")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - внешний ключ таблицы Кафедры
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - внешний ключ таблицы Должности
        /// </summary>
        public int? PositionId { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - кафедра
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Свойство таблицы Преподаватели - должность
        /// </summary>
        public virtual Position Position { get; set; }

        /// <summary>
        /// Коллекция успеваемостей
        /// </summary>
        public virtual ICollection<Transcript> Transcripts { get; set; }

        /// <summary>
        /// Коллекция пропусков
        /// </summary>
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
