using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Student")]
    public class Student
    {
        /// <summary>
        /// Свойство таблицы Студенты - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Студенты - фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите пожалуйста, фамилию студента")]
        public string SecondName { get; set; }

        /// <summary>
        /// Свойство таблицы Студенты - имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите пожалуйста, имя студента")]
        public string FirstName { get; set; }

        /// <summary>
        /// Свойство таблицы Студенты - отчество
        /// </summary>
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите пожалуйста, отчество студента")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Свойство таблицы Студенты - внешний ключ таблицы Группы
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// Свойство таблицы Студенты - группа
        /// </summary>
        public virtual GroupStudent Group { get; set; }

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
