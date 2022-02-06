using System;

namespace PISBusinessLogic.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string LibrarianFIO { get; set; }
        public double Sum { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

    }
}