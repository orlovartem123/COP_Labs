
using System;
using System.Runtime.Serialization;

namespace PISBusinessLogic.BindingModels
{
    [DataContract]
    public class LibraryCardBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public string ReaderFIO { get; set; }
        [DataMember]
        public int Extension { get; set; } //продление
        [DataMember]
        public string PlaceOfWork { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}