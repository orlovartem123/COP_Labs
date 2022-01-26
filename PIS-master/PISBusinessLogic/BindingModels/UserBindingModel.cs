using PISBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PISBusinessLogic.BindingModels
{
  
    public class UserBindingModel
    {      
        public int? Id { get; set; }
        [Required(ErrorMessage = "Введите ФИО")]
        public string FIO { get; set; }
        public string Comission { get; set; }
        public string ComissionPercent { get; set; }
        public Roles Role { get; set; }
        public string Salary { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите E-Mail")]
        [EmailAddress(ErrorMessage = "Введён некорректный E-Mail")]
        public string Email { get; set; }
        
    }
}
