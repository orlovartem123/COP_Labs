using System;

namespace Exam_My_Example.Database.Models
{
    /// <summary>
    /// Класс-модель (для базы данных) справочника 1
    /// </summary>
    internal class Spravochnik1
    {
        public int Id { get; set; }

        public string Fio { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Contacts { get; set; }

        public string Comment { get; set; }
    }

    /// <summary>
    /// Перечисление необходимое для того чтобы использовать вместо строк "Мужчина" или "Женищина" 
    /// просто цифры (0 или 1) и в коде было понятно что мы имеем ввиду
    /// </summary>
    internal enum Gender
    {
        Man = 0,
        Women = 1
    }
}
