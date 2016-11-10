using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("TypeControl")]
    public class TypeControl
    {
        /// <summary>
        /// Свойство таблицы Типы контроля - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Типы контроля - название
        /// </summary>
        [Display(Name = "Тип контроля")]
        [Required(ErrorMessage = "Введите пожалуйста, название типа контроля")]
        public string Name { get; set; }

        /// <summary>
        /// Коллекция успеваемостей
        /// </summary>
        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
