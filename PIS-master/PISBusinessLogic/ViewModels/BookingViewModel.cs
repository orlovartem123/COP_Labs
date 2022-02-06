using System;

namespace PISBusinessLogic.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int LibraryCardId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}