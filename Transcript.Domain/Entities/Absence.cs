using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Absence")]
    public class Absence
    {
        /// <summary>
        /// Свойство таблицы Пропуск - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - внешний ключ таблицы Студенты
        /// </summary>
        public int? StudentId { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - студент
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - внешний ключ таблицы Дисциплина
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - дисциплина
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - внешний ключ таблицы Преподаватели
        /// </summary>
        public int? TeacherId { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - преподаватель
        /// </summary>
        public virtual UniversityTeacher Teacher { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - внешний ключ таблицы Тип занятий
        /// </summary>
        public int? TypeClassId { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - тип занятий
        /// </summary>
        public virtual TypeClass TypeClass { get; set; }

        /// <summary>
        /// Свойство таблицы Пропуск - дата когда отсутствовал
        /// </summary>
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Дата отсутствия")]
        [Required(ErrorMessage = "Введите пожалуйста, дату отсутствия")]
        public DateTime? DateAbsence { get; set; }
    }
}
