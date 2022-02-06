﻿
using PISBusinessLogic.Enums;
using System;
using System.Collections.Generic;

namespace PISBusinessLogic.BindingModels
{
    public class ContractBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateReturn { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public double Fine { get; set; }
        public double Sum { get; set; }
        public int LibraryCardId { get; set; }
        public int LibrarianId { get; set; }
        public int BookingId { get; set; }
        public int BookId { get; set; }

        public List<ContractBookBindingModel> ContractBooks { get; set; }

    }
}