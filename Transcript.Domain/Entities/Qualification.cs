using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("Qualification")]
    public class Qualification
    {
        /// <summary>
        /// Свойство таблицы Квалификационный уровень - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Квалификационный уровень - название
        /// </summary>
        [Display(Name = "Квалификационный уровень")]
        [Required(ErrorMessage = "Введите пожалуйста, название квал. уровня")]
        public string Name { get; set; }

        /// <summary>
        /// Коллекция групп
        /// </summary>
        public virtual ICollection<GroupStudent> GroupsStudents { get; set; }
    }
}
