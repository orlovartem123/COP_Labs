using System;
using System.Runtime.Serialization;

namespace PISBusinessLogic.BindingModels
{
    [DataContract]
    public class PaymentBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public double Sum { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime Date {get;set;}

    }
}