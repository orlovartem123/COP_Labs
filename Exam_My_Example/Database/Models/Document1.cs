using System;

namespace Exam_My_Example.Database.Models
{
    /// <summary>
    /// Класс-модель (для базы данных) документа 1
    /// </summary>
    internal class Document1
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TypePriema TypePriema { get; set; }

        #region Внешние ключи

        /// <summary>
        /// Внешний ключ на сотрудника (справочник 2)
        /// </summary>
        public int Spravochnik2Id { get; set; }

        public Spravochnik2 Spravochnik2 { get; set; }


        /// <summary>
        /// Внешний ключ на пациента (справочник 1)
        /// </summary>
        public int Spravochnik1Id { get; set; }

        public Spravochnik1 Spravochnik1 { get; set; }

        #endregion

        public string Jalobi { get; set; }

        public string Diagnoz { get; set; }

        public string Naznachenia { get; set; }

        public DateTime DateVizdorovlenia { get; set; }
    }

    /// <summary>
    /// Перечисление необходимое для того чтобы использовать вместо строк "Первичный" или "Повторный" 
    /// просто цифры (0 или 1) и в коде было понятно что мы имеем ввиду
    /// </summary>
    internal enum TypePriema
    {
        Pervich = 0,
        Povtorn = 1
    }
}
