
using System;
using System.ComponentModel.DataAnnotations;

namespace PISBusinessLogic.ViewModels
{
    public class LibraryCardViewModel
    {
        public int Id { get; set; }
        public string ReaderFIO { get; set; }
        public string Year { get; set; }
        public string PlaceOfWork { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int Extension { get; set; } //продление

        public int? UserId { get; set; }
    }
}