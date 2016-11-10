using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcript.Domain.Entities
{
    [Table("User")]
    public class User
    {
        /// <summary>
        /// Свойство таблицы Пользователи - уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство таблицы Пользователи - логин
        /// </summary>
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите пожалуйста, логин")]
        public string Login { get; set; }

        /// <summary>
        /// Свойство таблицы Пользователи - пароль
        /// </summary>
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пожалуйста, пароль")]
        public string Password { get; set; }
    }
}
