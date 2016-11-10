using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("TypeClass")]
    public class TypeClass
    {
        /// <summary>
        /// Свойство таблицы Типы занятий - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Типы занятий - название
        /// </summary>
        [Display(Name = "Тип занятия")]
        [Required(ErrorMessage = "Введите пожалуйста, название типа занятия")]
        public string Name { get; set; }

        /// <summary>
        /// Коллекция пропусков
        /// </summary>
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
