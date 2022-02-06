using System;
using System.Runtime.Serialization;

namespace PISBusinessLogic.BindingModels
{
    [DataContract]
    public class BookingBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        public int BookId { get; set; }
        public int LibraryCardId { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }

    }
}