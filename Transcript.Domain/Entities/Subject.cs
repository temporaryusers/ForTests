using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Subject")]
    public class Subject
    {
        /// <summary>
        /// Свойство таблицы Предмет - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Предмет - название
        /// </summary>
        [Display(Name = "Дисциплина")]
        [Required(ErrorMessage = "Введите пожалуйста, название дисциплины")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Предмет - короткое название
        /// </summary>
        [Display(Name = "Абревиатура")]
        [Required(ErrorMessage = "Введите пожалуйста, короткое название дисциплины")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Свойство таблицы Предмет - внешний ключ таблицы Кафедры
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Свойство таблицы Предмет - кафедра
        /// </summary>
        public virtual Department Department { get; set; }

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
