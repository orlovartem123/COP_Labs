﻿using System;


namespace PISDatabaseimplements.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public DateTime Date {get;set;}
        public int UserId { get; set; }
        public virtual User Librarian { get; set; }
    }
}