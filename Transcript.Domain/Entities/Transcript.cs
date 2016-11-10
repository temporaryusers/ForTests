using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Transcript")]
    public class Transcript
    {
        /// <summary>
        /// Свойство таблицы Успеваемость - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - внешний ключ таблицы Студенты
        /// </summary>
        public int? StudentId { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - студент
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - внешний ключ таблицы Дисциплина
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - дисциплина
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - внешний ключ таблицы Преподаватели
        /// </summary>
        public int? TeacherId { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - преподаватель
        /// </summary>
        public virtual UniversityTeacher Teacher { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - внешний ключ таблицы Тип контроля
        /// </summary>
        public int? TypeControlId { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - тип контроля
        /// </summary>
        public virtual TypeControl TypeControl { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - оценка
        /// </summary>
        [Display(Name = "Рейтинг")]
        [Required(ErrorMessage = "Введите пожалуйста, рейтинг студента")]
        [Range(1, 100)]
        public int? Mark { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - год
        /// </summary>
        [Display(Name = "Год")]
        [Required(ErrorMessage = "Введите пожалуйста, год")]
        [Range(2000, 2100)]
        public int? Year { get; set; }

        /// <summary>
        /// Свойство таблицы Успеваемость - семестр
        /// </summary>
        [Display(Name = "Семестр")]
        [Required(ErrorMessage = "Введите пожалуйста, семестр")]
        [Range(1, 2)]
        public int? Semester { get; set; }
    }
}
