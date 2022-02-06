﻿using PISBusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace PISBusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Comission { get; set; }
        public string ComissionPercent { get; set; }
        private string _salary;
        public string Salary { get => _salary ?? "0"; set => _salary = value; }
        [DataType(DataType.Password)]
        public Roles Role { get; set; }
    }
}
