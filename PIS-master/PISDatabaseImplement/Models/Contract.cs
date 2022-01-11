﻿
using PISBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PISDatabaseimplements.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Date { get;set;}
        public DateTime DateReturn { get; set; }
        public double Sum { get; set; }
        public double Fine { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int LibraryCardId { get; set; }
        public int LibrarianId { get; set; }
        [ForeignKey("ContractId")]
        public virtual List<ContractBook> BookContracts { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
        public virtual User Librarian { get; set; }
    }
}