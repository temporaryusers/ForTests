using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Speciality")]
    public class Speciality
    {
        /// <summary>
        /// Свойство таблицы Специальность - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Специальность - название
        /// </summary>
        [Display(Name = "Специальность")]
        [Required(ErrorMessage = "Введите пожалуйста, название специальности")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Специальность - код
        /// </summary>
        [Display(Name = "Код")]
        [Required(ErrorMessage = "Введите пожалуйста, код специальности")]
        public string Code { get; set; }

        /// <summary>
        /// Свойство таблицы Специальность - короткое название
        /// </summary>
        [Display(Name = "Абревиатура")]
        [Required(ErrorMessage = "Введите пожалуйста, короткое название специальности")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Свойство таблицы Специальность - внешний ключ таблицы Кафедры
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Свойство таблицы Специальность - кафедра
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Коллекция групп
        /// </summary>
        public virtual ICollection<GroupStudent> GroupsStudents { get; set; }
    }
}
