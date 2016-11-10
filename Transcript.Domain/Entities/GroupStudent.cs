using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transcript.Domain.Entities
{
    [Table("GroupStudent")]
    public class GroupStudent
    {
        /// <summary>
        /// Свойство таблицы Группа - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - название
        /// </summary>
        [Display(Name = "Группа")]
        [Required(ErrorMessage = "Введите пожалуйста, название группы")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - внешний ключ таблицы Специальности
        /// </summary>
        public int? SpecialityId { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - внешний ключ таблицы Квалификационные уровни
        /// </summary>
        public int? QualificationId { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - курс
        /// </summary>
        [Display(Name = "Курс")]
        [Required(ErrorMessage = "Введите пожалуйста, курс группы")]
        [Range(1, 6)]
        public int Course { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - квалификационный уровень
        /// </summary>
        public virtual Qualification Qualification { get; set; }

        /// <summary>
        /// Свойство таблицы Группа - специальность
        /// </summary>
        public virtual Speciality Speciality { get; set; }

        /// <summary>
        /// Коллекция студентов группы
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }
    }
}
