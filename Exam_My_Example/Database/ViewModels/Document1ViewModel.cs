using Exam_My_Example.Database.Models;
using System;

namespace Exam_My_Example.Database.ViewModels
{
    /// <summary>
    /// Класс-модель которая содержит в себе все поля сущности Document1, а также дополнительные поля
    /// необходимые для того чтобы выводились не внешние ключи связанных сущностей в таблице,
    /// а например имена или любое другое понятное название
    /// </summary>
    internal class Document1ViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TypePriema TypePriema { get; set; }

        public string Spravochnik2Name { get; set; }

        public string Spravochnik1Name { get; set; }

        public string Jalobi { get; set; }

        public string Diagnoz { get; set; }

        public string Naznachenia { get; set; }

        public DateTime DateVizdorovlenia { get; set; }
    }
}
