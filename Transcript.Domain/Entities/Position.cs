using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Position")]
    public class Position
    {
        /// <summary>
        /// Свойство таблицы Должность - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Должность - название
        /// </summary>
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Введите пожалуйста, название должности")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Должность - короткое название
        /// </summary>
        [Display(Name = "Абревиатура")]
        [Required(ErrorMessage = "Введите пожалуйста, короткое название должности")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Коллекция преподавателей
        /// </summary>
        public virtual ICollection<UniversityTeacher> Teachers { get; set; }
    }
}
