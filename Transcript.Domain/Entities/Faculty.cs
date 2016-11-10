using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Faculty")]
    public class Faculty
    {
        /// <summary>
        /// Свойство таблицы Факультет - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Факультет - название
        /// </summary>
        [Display(Name = "Факультет")]
        [Required(ErrorMessage = "Введите пожалуйста, название факультета")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Факультет - короткое название
        /// </summary>
        [Display(Name = "Абревиатура")]
        [Required(ErrorMessage = "Введите пожалуйста, короткое название факультета")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Свойство таблицы Факультет - номер
        /// </summary>
        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Введите пожалуйста, номер факультета")]
        public int Number { get; set; }

        /// <summary>
        /// Коллекция кафедр факультета
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
